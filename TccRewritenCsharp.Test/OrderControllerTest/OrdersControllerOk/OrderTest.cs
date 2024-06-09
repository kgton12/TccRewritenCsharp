using Bogus;
using FluentAssertions;
using TccRewritenCsharp.Application.UseCases.Order.Delete;
using TccRewritenCsharp.Application.UseCases.Order.Get;
using TccRewritenCsharp.Application.UseCases.Order.GetFull;
using TccRewritenCsharp.Application.UseCases.Order.GetId;
using TccRewritenCsharp.Application.UseCases.Order.Register;
using TccRewritenCsharp.Application.UseCases.Order.Update;
using TccRewritenCsharp.Application.UseCases.User.Get;
using TccRewritenCsharp.Application.UseCases.User.Register;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Requests.User;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Test.OrderControllerTest.OrdersControllerOk
{
    public class OrderTest
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public OrderTest()
        {
            OrderId = Guid.Empty;
            UserId = Guid.Empty;
        }

        [Fact]
        public async Task ExecuteAllTest()
        {
            await RegisterOrderTestOk();
            await GetOrderByIdTestOk();
            await GetOrderTestOk();
            await GetFullOrderTestOk();
            await UpdateOrderByIdTestOk();
            await DeleteOrderByIdTestOk();
        }

        internal async Task RegisterOrderTestOk()
        {

            UserId = await CheckIfIxistsUser();

            var request = new Faker<RequestOrderJson>()
                .RuleFor(x => x.UserId, f => UserId)
                .RuleFor(x => x.Quantity, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Status, f => f.PickRandom<Status>())
                .Generate();

            var useCase = new RegisterOrderUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(request);
            OrderId = response.Id;

            response.Should().BeOfType<ResponseOrderIdJson>();
        }
        internal async Task GetOrderByIdTestOk()
        {
            var useCase = new GetOrderByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(OrderId);

            response.Should().BeOfType<ResponseOrderJson>();
        }
        internal async Task GetOrderTestOk()
        {
            var useCase = new GetOrderUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute();

            response.Should().BeOfType<List<ResponseOrderJson>>();
        }
        internal async Task GetFullOrderTestOk()
        {
            var useCase = new GetFullOrderByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(OrderId);

            response.Should().BeOfType<ResponseFullOrderJson>();
        }
        internal async Task UpdateOrderByIdTestOk()
        {
            var request = new Faker<RequestOrderJson>()
                .RuleFor(x => x.UserId, f => UserId)
                .RuleFor(x => x.Quantity, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Status, f => f.PickRandom<Status>())
                .Generate();

            var useCase = new UpdateOrderByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(OrderId, request);

            response.Should().BeOfType<ResponseOrderIdJson>();
        }
        internal async Task DeleteOrderByIdTestOk()
        {
            var useCase = new DeleteOrderByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(OrderId);

            response.Should().BeOfType<ResponseOrderIdJson>();
        }

        public async Task<Guid> CheckIfIxistsUser()
        {
            var UserUseCase = new GetUserUseCase(ServiceEnvironment.Development);

            var UserResponse = await UserUseCase.Execute();

            if (UserResponse.Count > 0)
            {
                return UserResponse[0].Id;
            }
            else
            {
                var request = new Faker<RequestUserJson>()
               .RuleFor(x => x.Name, f => f.Person.FirstName)
               .RuleFor(x => x.LastName, f => f.Person.LastName)
               .RuleFor(x => x.Login, f => f.Person.UserName)
               .RuleFor(x => x.PassWord, f => f.Internet.Password())
               .RuleFor(x => x.Email, f => f.Person.Email)
               .RuleFor(x => x.Admin, f => f.Random.Bool())
               .RuleFor(x => x.Telephone, f => f.Person.Phone)
               .RuleFor(x => x.Address, f => f.Address.StreetName())
               .RuleFor(x => x.City, f => f.Address.City())
               .RuleFor(x => x.State, f => f.Address.State())
               .RuleFor(x => x.Country, f => f.Address.Country())
               .RuleFor(x => x.ZipCode, f => f.Address.ZipCode())
               .RuleFor(x => x.Number, f => f.Address.BuildingNumber())
               .Generate();

                var RegisterUseCase = new RegisterUserUseCase(ServiceEnvironment.Development);

                var response = await RegisterUseCase.Execute(request);
                return response.Id;
            }
        }
    }
}

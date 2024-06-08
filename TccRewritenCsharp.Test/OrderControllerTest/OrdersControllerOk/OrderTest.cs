using Bogus;
using FluentAssertions;
using TccRewritenCsharp.Application.UseCases.Order.Delete;
using TccRewritenCsharp.Application.UseCases.Order.Get;
using TccRewritenCsharp.Application.UseCases.Order.GetFull;
using TccRewritenCsharp.Application.UseCases.Order.GetId;
using TccRewritenCsharp.Application.UseCases.Order.Register;
using TccRewritenCsharp.Application.UseCases.Order.Update;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Test.OrderControllerTest.OrdersControllerOk
{
    public class OrderTest
    {
        public Guid OrderId { get; set; }
        public OrderTest()
        {
            OrderId = Guid.Empty;
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
            Guid newGuid = new("C3B3DB8D-9F54-4933-9098-8A9BAAB0FD38");
            var request = new Faker<RequestOrderJson>()
                .RuleFor(x => x.UserId, f => newGuid)
                .RuleFor(x => x.Quantity, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Status, f => f.PickRandom<Status>())
                .Generate();

            var useCase = new RegisterOrderUseCase();

            var response = await useCase.Execute(request);
            OrderId = response.Id;

            response.Should().BeOfType<ResponseOrderIdJson>();
        }
        internal async Task GetOrderByIdTestOk()
        {
            var useCase = new GetOrderByIdUseCase();

            var response = await useCase.Execute(OrderId);

            response.Should().BeOfType<ResponseOrderJson>();
        }
        internal async Task GetOrderTestOk()
        {
            var useCase = new GetOrderUseCase();

            var response = await useCase.Execute();

            response.Should().BeOfType<List<ResponseOrderJson>>();
        }
        internal async Task GetFullOrderTestOk()
        {
            var useCase = new GetFullOrderByIdUseCase();

            var response = await useCase.Execute(OrderId);

            response.Should().BeOfType<ResponseFullOrderJson>();
        }
        internal async Task UpdateOrderByIdTestOk()
        {
            Guid newGuid = new("C3B3DB8D-9F54-4933-9098-8A9BAAB0FD38");
            var request = new Faker<RequestOrderJson>()
                .RuleFor(x => x.UserId, f => newGuid)
                .RuleFor(x => x.Quantity, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Status, f => f.PickRandom<Status>())
                .Generate();

            var useCase = new UpdateOrderByIdUseCase();

            var response = await useCase.Execute(OrderId, request);

            response.Should().BeOfType<ResponseOrderIdJson>();
        }
        internal async Task DeleteOrderByIdTestOk()
        {
            var useCase = new DeleteOrderByIdUseCase();

            var response = await useCase.Execute(OrderId);

            response.Should().BeOfType<ResponseOrderIdJson>();
        }
    }
}

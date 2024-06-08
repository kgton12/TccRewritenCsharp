using Bogus;
using FluentAssertions;
using TccRewritenCsharp.Application.UseCases.User.Delete;
using TccRewritenCsharp.Application.UseCases.User.Get;
using TccRewritenCsharp.Application.UseCases.User.GetId;
using TccRewritenCsharp.Application.UseCases.User.Register;
using TccRewritenCsharp.Application.UseCases.User.Update;
using TccRewritenCsharp.Communication.Requests.User;
using TccRewritenCsharp.Communication.Response.User;

namespace TccRewritenCsharp.Test.UsersControllerTest.UsersControllerOk
{
    public class UserTest
    {
        public Guid UserId { get; set; }
        public UserTest()
        {
            UserId = Guid.Empty;
        }
        [Fact]
        public async Task ExecuteAllTest()
        {
            await RegisterUserTestOk();
            await GetUserByIdTestOk();
            await GetUserTestOk();
            await UpdateUserByIdTestOk();
            await DeleteUserByIdTestOk();
        }

        internal async Task RegisterUserTestOk()
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

            var useCase = new RegisterUserUseCase();

            var response = await useCase.Execute(request);
            UserId = response.Id;

            response.Should().BeOfType<ResponseUserIdJson>();
        }
        internal async Task GetUserByIdTestOk()
        {
            var useCase = new GetUserByIdUseCase();

            var response = await useCase.Execute(UserId);

            response.Should().BeOfType<ResponseOrderUserJson>();
        }
        internal async Task GetUserTestOk()
        {
            var useCase = new GetUserUseCase();

            var response = await useCase.Execute();

            response.Should().BeOfType<List<ResponseOrderUserJson>>();
        }
        internal async Task UpdateUserByIdTestOk()
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
            var useCase = new UpdateUserByIdUseCase();

            var response = await useCase.Execute(UserId, request);

            response.Should().BeOfType<ResponseUserIdJson>();
        }
        internal async Task DeleteUserByIdTestOk()
        {
            var useCase = new DeleteUserByIdUseCase();

            var response = await useCase.Execute(UserId);

            response.Should().BeOfType<ResponseUserIdJson>();
        }
    }
}

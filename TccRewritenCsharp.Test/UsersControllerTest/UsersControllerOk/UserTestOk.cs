﻿using Bogus;
using FluentAssertions;
using TccRewritenCsharp.Application.UseCases.User.Delete;
using TccRewritenCsharp.Application.UseCases.User.Get;
using TccRewritenCsharp.Application.UseCases.User.GetId;
using TccRewritenCsharp.Application.UseCases.User.Register;
using TccRewritenCsharp.Application.UseCases.User.Update;
using TccRewritenCsharp.Communication.Requests.User;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Test.UsersControllerTest.UsersControllerOk
{
    public class UserTestOk
    {
        public Guid UserId { get; set; }
        public UserTestOk()
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

            var useCase = new RegisterUserUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(request);
            UserId = response.Id;

            response.Should().BeOfType<ResponseIdJson>()
                .And.Match<ResponseIdJson>(r => r.StatusCode == StatusCode.Ok && r.Status == StatusJson.Success);
        }
        internal async Task GetUserByIdTestOk()
        {
            var useCase = new GetUserByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(UserId);

            response.Should().BeOfType<ResponseUserJson>()
                .And.Match<ResponseUserJson>(r => r.StatusCode == StatusCode.Ok && r.Status == StatusJson.Success);
        }
        internal static async Task GetUserTestOk()
        {
            var useCase = new GetUserUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute();

            response.Should().BeOfType<List<ResponseAllGetUserJson>>()
                .And.Match<List<ResponseAllGetUserJson>>(r => r.All(user => user.StatusCode == StatusCode.Ok && user.Status == StatusJson.Success));
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
            var useCase = new UpdateUserByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(UserId, request);

            response.Should().BeOfType<ResponseIdJson>()
                .And.Match<ResponseIdJson>(r => r.StatusCode == StatusCode.Ok && r.Status == StatusJson.Success);
        }
        internal async Task DeleteUserByIdTestOk()
        {
            var useCase = new DeleteUserByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(UserId);

            response.Should().BeOfType<ResponseIdJson>()
                .And.Match<ResponseIdJson>(r => r.StatusCode == StatusCode.Ok && r.Status == StatusJson.Success);
        }
    }
}

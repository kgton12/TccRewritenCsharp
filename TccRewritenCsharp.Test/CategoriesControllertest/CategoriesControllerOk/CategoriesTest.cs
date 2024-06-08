using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Application.UseCases.Category.Delete;
using TccRewritenCsharp.Application.UseCases.Category.Get;
using TccRewritenCsharp.Application.UseCases.Category.GetId;
using TccRewritenCsharp.Application.UseCases.Category.Register;
using TccRewritenCsharp.Application.UseCases.Category.Update;
using TccRewritenCsharp.Application.UseCases.User.Delete;
using TccRewritenCsharp.Application.UseCases.User.Get;
using TccRewritenCsharp.Application.UseCases.User.GetId;
using TccRewritenCsharp.Application.UseCases.User.Register;
using TccRewritenCsharp.Application.UseCases.User.Update;
using TccRewritenCsharp.Communication.Requests.Category;
using TccRewritenCsharp.Communication.Requests.User;
using TccRewritenCsharp.Communication.Response.Category;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure.Entities;

namespace TccRewritenCsharp.Test.CategoriesControllertest.CategoriesControllerOk
{
    public class CategoriesTest
    {
        public Guid CategoryId { get; set; }
        public CategoriesTest()
        {
            CategoryId = Guid.Empty;
        }

        [Fact]
        public async Task Execute_All_Test()
        {
            await RegisterCategoryTestOk();
            await GetCategoryByIdTestOk();
            await GetCategoryTestOk();
            await UpdateCategoryByIdTestOk();
            await DeleteCategoryByIdTestOk();
        }

        internal async Task RegisterCategoryTestOk()
        {
            var request = new Faker<RequestCategoryJson>()
                .RuleFor(x => x.Name, f => f.Lorem.Word())
                .RuleFor(x => x.Description, f => f.Lorem.Word())
                .Generate();

            var useCase = new RegisterCategoryUseCase();

            var response = await useCase.Execute(request);
            CategoryId = response.Id;

            response.Should().BeOfType<ResponseCategoryIdJson>();
        }
        internal async Task GetCategoryByIdTestOk()
        {
            var useCase = new GetCategoryrByIdUseCase();

            var response = await useCase.Execute(CategoryId);

            response.Should().BeOfType<ResponseCategoryJson>();
        }
        internal async Task GetCategoryTestOk()
        {
            var useCase = new GetCategoryUseCase();

            var response = await useCase.Execute();

            response.Should().BeOfType<List<ResponseCategoryJson>>();
        }
        internal async Task UpdateCategoryByIdTestOk()
        {
            var request = new Faker<RequestCategoryJson>()
                .RuleFor(x => x.Name, f => f.Lorem.Word())
                .RuleFor(x => x.Description, f => f.Lorem.Word())
                .Generate();
            var useCase = new UpdateCategoryByIdUseCase();

            var response = await useCase.Execute(CategoryId, request);

            response.Should().BeOfType<ResponseCategoryIdJson>();
        }
        internal async Task DeleteCategoryByIdTestOk()
        {
            var useCase = new DeleteCategoryByIdUseCase();

            var response = await useCase.Execute(CategoryId);

            response.Should().BeOfType<ResponseCategoryIdJson>();
        }

    }
}

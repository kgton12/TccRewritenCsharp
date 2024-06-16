using Bogus;
using FluentAssertions;
using TccRewritenCsharp.Application.UseCases.Category.Delete;
using TccRewritenCsharp.Application.UseCases.Category.Get;
using TccRewritenCsharp.Application.UseCases.Category.GetId;
using TccRewritenCsharp.Application.UseCases.Category.Register;
using TccRewritenCsharp.Application.UseCases.Category.Update;
using TccRewritenCsharp.Communication.Requests.Category;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Communication.Response.Category;
using TccRewritenCsharp.Infrastructure.Enums;

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

            var useCase = new RegisterCategoryUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(request);
            CategoryId = response.Id;

            response.Should().BeOfType<ResponseIdJson>();
        }
        internal async Task GetCategoryByIdTestOk()
        {
            var useCase = new GetCategoryrByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(CategoryId);

            response.Should().BeOfType<ResponseCategoryJson>();
        }
        internal static async Task GetCategoryTestOk()
        {
            var useCase = new GetCategoryUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute();

            response.Should().BeOfType<List<ResponseAllGetCategoryJson>>();
        }
        internal async Task UpdateCategoryByIdTestOk()
        {
            var request = new Faker<RequestCategoryJson>()
                .RuleFor(x => x.Name, f => f.Lorem.Word())
                .RuleFor(x => x.Description, f => f.Lorem.Word())
                .Generate();
            var useCase = new UpdateCategoryByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(CategoryId, request);

            response.Should().BeOfType<ResponseIdJson>();
        }
        internal async Task DeleteCategoryByIdTestOk()
        {
            var useCase = new DeleteCategoryByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(CategoryId);

            response.Should().BeOfType<ResponseIdJson>();
        }
    }
}

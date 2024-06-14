using Bogus;
using FluentAssertions;
using TccRewritenCsharp.Application.UseCases.Category.Get;
using TccRewritenCsharp.Application.UseCases.Category.Register;
using TccRewritenCsharp.Application.UseCases.Product.Delete;
using TccRewritenCsharp.Application.UseCases.Product.Get;
using TccRewritenCsharp.Application.UseCases.Product.GetId;
using TccRewritenCsharp.Application.UseCases.Product.Register;
using TccRewritenCsharp.Application.UseCases.Product.Update;
using TccRewritenCsharp.Communication.Requests.Category;
using TccRewritenCsharp.Communication.Requests.Product;
using TccRewritenCsharp.Communication.Response.Product;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Test.ProductControllerTest.ProductControllerOK
{
    public class ProductTest
    {
        public Guid ProductId { get; set; }
        public Guid CategoryId { get; set; }
        public ProductTest()
        {
            ProductId = Guid.Empty;
            CategoryId = Guid.Empty;
        }

        [Fact]
        public async Task Execute_All_Test()
        {
            await RegisterProductTestOk();
            await GetProductByIdTestOk();
            await GetProductTestOk();
            await UpdateProductByIdTestOk();
            await DeleteProductByIdTestOk();
        }

        internal async Task RegisterProductTestOk()
        {
            CategoryId = await CheckIfIxistsCategory();

            var request = new Faker<RequestProductJson>()
                .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Price, f => f.Random.Decimal(0, 1000))
                .RuleFor(x => x.Stock, f => f.Random.Int(0, 1000))
                .RuleFor(x => x.Image, f => f.Image.PicsumUrl())
                .RuleFor(x => x.CategoryId, CategoryId)
                .Generate();

            var useCase = new RegisterProductUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(request);
            ProductId = response.Id;

            response.Should().BeOfType<ResponseProductIdJson>();
        }

        internal async Task GetProductByIdTestOk()
        {
            var useCase = new GetProductByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(ProductId);

            response.Should().BeOfType<ResponseGetProductJson>();
        }

        internal static async Task GetProductTestOk()
        {
            var useCase = new GetProductUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute();

            response.Should().BeOfType<List<ResponseGetProductJson>>();
        }

        internal async Task UpdateProductByIdTestOk()
        {
            var request = new Faker<RequestProductJson>()
                .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Price, f => f.Random.Decimal(0, 1000))
                .RuleFor(x => x.Stock, f => f.Random.Int(0, 1000))
                .RuleFor(x => x.Image, f => f.Image.PicsumUrl())
                .RuleFor(x => x.CategoryId, CategoryId)
                .Generate();

            var useCase = new UpdateProductByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(ProductId, request);

            response.Should().BeOfType<ResponseProductIdJson>();
        }

        internal async Task DeleteProductByIdTestOk()
        {
            var useCase = new DeleteProductByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(ProductId);

            response.Should().BeOfType<ResponseProductIdJson>();
        }
        public static async Task<Guid> CheckIfIxistsCategory()
        {
            var useCaseCategory = new GetCategoryUseCase(ServiceEnvironment.Development);

            var responseCategory = await useCaseCategory.Execute();

            if (responseCategory.Status == StatusJson.Success)
            {
                return responseCategory.CategoryJsons[0].Id;
            }
            else
            {
                var request = new Faker<RequestCategoryJson>()
               .RuleFor(x => x.Name, f => f.Lorem.Word())
               .RuleFor(x => x.Description, f => f.Lorem.Word())
               .Generate();

                var useCaseRegisterCategory = new RegisterCategoryUseCase(ServiceEnvironment.Development);

                var response = await useCaseRegisterCategory.Execute(request);
                return response.Id;
            }
        }

    }
}

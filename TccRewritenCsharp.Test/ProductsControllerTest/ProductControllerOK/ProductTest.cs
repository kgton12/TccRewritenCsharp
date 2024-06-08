using Bogus;
using FluentAssertions;
using TccRewritenCsharp.Application.UseCases.Product.Delete;
using TccRewritenCsharp.Application.UseCases.Product.Get;
using TccRewritenCsharp.Application.UseCases.Product.GetId;
using TccRewritenCsharp.Application.UseCases.Product.Register;
using TccRewritenCsharp.Application.UseCases.Product.Update;
using TccRewritenCsharp.Communication.Requests.Product;
using TccRewritenCsharp.Communication.Response.Product;

namespace TccRewritenCsharp.Test.ProductControllerTest.ProductControllerOK
{
    public class ProductTest
    {
        public Guid ProductId { get; set; }
        public ProductTest()
        {
            ProductId = Guid.Empty;
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
            Guid newGuid = new("DC087613-413C-4BD8-8C95-6A4525C5DE2B");

            var request = new Faker<RequestProductJson>()
                .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Price, f => f.Random.Decimal(0, 1000))
                .RuleFor(x => x.Stock, f => f.Random.Int(0, 1000))
                .RuleFor(x => x.Image, f => f.Image.PicsumUrl())
                .RuleFor(x => x.CategoryId, newGuid)
                .Generate();

            var useCase = new RegisterProductUseCase();

            var response = await useCase.Execute(request);
            ProductId = response.Id;

            response.Should().BeOfType<ResponseProductIdJson>();
        }
        internal async Task GetProductByIdTestOk()
        {
            var useCase = new GetProductByIdUseCase();

            var response = await useCase.Execute(ProductId);

            response.Should().BeOfType<ResponseGetProductJson>();
        }
        internal async Task GetProductTestOk()
        {
            var useCase = new GetProductUseCase();

            var response = await useCase.Execute();

            response.Should().BeOfType<List<ResponseGetProductJson>>();
        }
        internal async Task UpdateProductByIdTestOk()
        {
            Guid newGuid = new("DC087613-413C-4BD8-8C95-6A4525C5DE2B");

            var request = new Faker<RequestProductJson>()
                .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.Price, f => f.Random.Decimal(0, 1000))
                .RuleFor(x => x.Stock, f => f.Random.Int(0, 1000))
                .RuleFor(x => x.Image, f => f.Image.PicsumUrl())
                .RuleFor(x => x.CategoryId, newGuid)
                .Generate();

            var useCase = new UpdateProductByIdUseCase();

            var response = await useCase.Execute(ProductId, request);

            response.Should().BeOfType<ResponseProductIdJson>();
        }
        internal async Task DeleteProductByIdTestOk()
        {
            var useCase = new DeleteProductByIdUseCase();

            var response = await useCase.Execute(ProductId);

            response.Should().BeOfType<ResponseProductIdJson>();
        }

    }
}

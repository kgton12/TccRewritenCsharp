using Bogus;
using FluentAssertions;
using TccRewritenCsharp.Application.UseCases.Order.Get;
using TccRewritenCsharp.Application.UseCases.Order.Register;
using TccRewritenCsharp.Application.UseCases.OrderItems.Delete;
using TccRewritenCsharp.Application.UseCases.OrderItems.Get;
using TccRewritenCsharp.Application.UseCases.OrderItems.Register;
using TccRewritenCsharp.Application.UseCases.OrderItems.Update;
using TccRewritenCsharp.Application.UseCases.Product.Get;
using TccRewritenCsharp.Application.UseCases.Product.Register;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Requests.OrderItems;
using TccRewritenCsharp.Communication.Requests.Product;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure.Enums;
using TccRewritenCsharp.Test.OrderControllerTest.OrdersControllerOk;
using TccRewritenCsharp.Test.ProductControllerTest.ProductControllerOK;

namespace TccRewritenCsharp.Test.OrderItemItemsControllerTest.OrderItemItemsControllerOk
{
    public class OrderItemItemsTest
    {
        public Guid OrderId { get; set; }
        public Guid OrderItemId { get; set; }
        public Guid ProductId { get; set; }
        public OrderItemItemsTest()
        {
            OrderId = Guid.Empty;
            OrderItemId = Guid.Empty;
            ProductId = Guid.Empty;
        }

        [Fact]
        public async Task ExecuteAllTest()
        {
            await RegisterOrderItemTestOk();
            await GetOrderItemByIdTestOk();
            await GetOrderItemTestOk();
            await UpdateOrderItemByIdTestOk();
            await DeleteOrderItemByIdTestOk();
        }

        internal async Task RegisterOrderItemTestOk()
        {
            OrderId = await CheckIfIxistsOrder();
            ProductId = await CheckIfIxistsProduct();

            var request = new Faker<RequestOrderItemsJson>()
                .RuleFor(x => x.OrderId, f => OrderId)
                .RuleFor(x => x.ProductId, f => ProductId)
                .RuleFor(x => x.Quantity, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Total, f => f.Random.Decimal(1, 1000))
                .RuleFor(x => x.UnitaryValue, f => f.Random.Decimal(1, 1000))
                .Generate();

            var useCase = new RegisterOrderItemsUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(request);
            OrderItemId = response.Id;

            response.Should().BeOfType<ResponseOrderItemsIdJson>();
        }
        internal async Task GetOrderItemByIdTestOk()
        {
            var useCase = new GetFullOrderItemUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(OrderId);

            response.Should().BeOfType<List<ResponseGetOrderItemsJson>>();
        }
        internal async Task GetOrderItemTestOk()
        {
            var useCase = new GetFullOrderItemUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(OrderId);

            response.Should().BeOfType<List<ResponseGetOrderItemsJson>>();
        }
        internal async Task UpdateOrderItemByIdTestOk()
        {
            var request = new Faker<RequestOrderItemsJson>()
                .RuleFor(x => x.OrderId, f => OrderId)
                .RuleFor(x => x.ProductId, f => ProductId)
                .RuleFor(x => x.Quantity, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Total, f => f.Random.Decimal(1, 1000))
                .RuleFor(x => x.UnitaryValue, f => f.Random.Decimal(1, 1000))
                .Generate();

            var useCase = new UpdateOrderItemByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(OrderItemId, request);

            response.Should().BeOfType<ResponseOrderItemsIdJson>();
        }
        internal async Task DeleteOrderItemByIdTestOk()
        {
            var useCase = new DeleteOrderItemsByIdUseCase(ServiceEnvironment.Development);

            var response = await useCase.Execute(OrderItemId);

            response.Should().BeOfType<ResponseOrderItemsIdJson>();
        }

        internal static async Task<Guid> CheckIfIxistsOrder()
        {
            var orderUseCase = new GetOrderUseCase(ServiceEnvironment.Development);

            var orderResponse = await orderUseCase.Execute();

            if (orderResponse.Count > 0)
            {
                return orderResponse[0].Id;
            }
            else
            {
                var orderTestUseCase = new OrderTest();
                var userId = await orderTestUseCase.CheckIfIxistsUser();

                var request = new Faker<RequestOrderJson>()
                 .RuleFor(x => x.UserId, f => userId)
                 .RuleFor(x => x.Quantity, f => f.Random.Int(1, 100))
                 .RuleFor(x => x.Status, f => f.PickRandom<Status>())
                 .Generate();

                var registerOrderUseCase = new RegisterOrderUseCase(ServiceEnvironment.Development);

                var response = await registerOrderUseCase.Execute(request);
                return response.Id;
            }
        }

        internal static async Task<Guid> CheckIfIxistsProduct()
        {
            var GetProductUseCase = new GetProductUseCase(ServiceEnvironment.Development);

            var ProductResponse = await GetProductUseCase.Execute();

            if (ProductResponse.Count > 0)
            {
                return ProductResponse[0].Id;
            }
            else
            {
                var ProductTestUseCase = new ProductTest();
                var CategoryId = await ProductTestUseCase.CheckIfIxistsCategory();

                var request = new Faker<RequestProductJson>()
               .RuleFor(x => x.Name, f => f.Commerce.ProductName())
               .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
               .RuleFor(x => x.Price, f => f.Random.Decimal(0, 1000))
               .RuleFor(x => x.Stock, f => f.Random.Int(0, 1000))
               .RuleFor(x => x.Image, f => f.Image.PicsumUrl())
               .RuleFor(x => x.CategoryId, CategoryId)
               .Generate();

                var registerProductUseCase = new RegisterProductUseCase(ServiceEnvironment.Development);

                var productResponse = await registerProductUseCase.Execute(request);

                return productResponse.Id;
            }
        }
    }
}

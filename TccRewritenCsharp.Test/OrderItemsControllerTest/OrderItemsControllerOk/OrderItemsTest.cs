using Bogus;
using FluentAssertions;
using TccRewritenCsharp.Application.UseCases.OrderItems.Delete;
using TccRewritenCsharp.Application.UseCases.OrderItems.Get;
using TccRewritenCsharp.Application.UseCases.OrderItems.Register;
using TccRewritenCsharp.Application.UseCases.OrderItems.Update;
using TccRewritenCsharp.Communication.Requests.OrderItems;
using TccRewritenCsharp.Communication.Response.OrderItems;

namespace TccRewritenCsharp.Test.OrderItemItemsControllerTest.OrderItemItemsControllerOk
{
    public class OrderItemItemsTest
    {
        public Guid OrderId { get; set; }
        public Guid OrderItemId { get; set; }
        public Guid ProductId { get; set; }
        public OrderItemItemsTest()
        {
            OrderId = new("F05F64F8-1725-439C-B482-4ADB50FFDC2F");
            OrderItemId = Guid.Empty;
            ProductId = new("25087EAA-43AB-4ECC-BE17-70FC10B3ECFE");
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
            var request = new Faker<RequestOrderItemsJson>()
                .RuleFor(x => x.OrderId, f => OrderId)
                .RuleFor(x => x.ProductId, f => ProductId)
                .RuleFor(x => x.Quantity, f => f.Random.Int(1, 100))
                .RuleFor(x => x.Total, f => f.Random.Decimal(1, 1000))
                .RuleFor(x => x.UnitaryValue, f => f.Random.Decimal(1, 1000))
                .Generate();

            var useCase = new RegisterOrderItemsUseCase();

            var response = await useCase.Execute(request);
            OrderItemId = response.Id;

            response.Should().BeOfType<ResponseOrderItemsIdJson>();
        }
        internal async Task GetOrderItemByIdTestOk()
        {
            var useCase = new GetFullOrderItemUseCase();

            var response = await useCase.Execute(OrderId);

            response.Should().BeOfType<List<ResponseGetOrderItemsJson>>();
        }
        internal async Task GetOrderItemTestOk()
        {
            var useCase = new GetFullOrderItemUseCase();

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

            var useCase = new UpdateOrderItemByIdUseCase();

            var response = await useCase.Execute(OrderItemId, request);

            response.Should().BeOfType<ResponseOrderItemsIdJson>();
        }
        internal async Task DeleteOrderItemByIdTestOk()
        {
            var useCase = new DeleteOrderItemsByIdUseCase();

            var response = await useCase.Execute(OrderItemId);

            response.Should().BeOfType<ResponseOrderItemsIdJson>();
        }
    }
}

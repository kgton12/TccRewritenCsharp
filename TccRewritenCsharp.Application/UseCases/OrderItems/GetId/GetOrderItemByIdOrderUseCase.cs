using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.GetId
{
    public class GetOrderItemByIdOrderUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetOrderItemByIdOrderUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
        {
            _dbContext = new TccRewritenCsharpDbContext(environment);
        }
        public async Task<ResponseGetOrderItemsJson> Execute(Guid id)
        {
            var orderItem = await _dbContext.OrderItem.Where(x => x.Id == id).Select(x => new ResponseGetOrderItemsJson
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Total = x.Total,
                UnitaryValue = x.UnitaryValue
            }).FirstOrDefaultAsync();

            return orderItem ?? throw new Exception("Order Item not found");
        }
    }
}

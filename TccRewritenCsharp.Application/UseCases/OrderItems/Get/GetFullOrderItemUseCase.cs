using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Get
{
    public class GetFullOrderItemUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetFullOrderItemUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
        {
            _dbContext = new TccRewritenCsharpDbContext(environment);
        }
        public async Task<List<ResponseGetOrderItemsJson>> Execute(Guid idOrder)
        {
            var orderItem = await _dbContext.OrderItem.Where(o => o.OrderId == idOrder).Select(x => new ResponseGetOrderItemsJson
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Total = x.Total,
                UnitaryValue = x.UnitaryValue
            }).ToListAsync();

            return orderItem ?? throw new Exception("Order Items not found");
        }
    }
}

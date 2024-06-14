using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Get
{
    public class GetFullOrderItemUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<List<ResponseGetOrderItemsJson>> Execute(Guid OrderId)
        {
            var response = new List<ResponseGetOrderItemsJson>()
            {
                new("",StatusJson.Success, StatusCode.Ok)
                {
                    OrderItem = await _dbContext.OrderItem.Where(x => x.OrderId == OrderId).Select(x => new OrderItemJson
                    {
                       Id = x.Id,
                       OrderId = x.OrderId,
                       ProductId = x.ProductId,
                       Quantity = x.Quantity,
                       UnitaryValue = x.UnitaryValue,
                       Total = x.Total
                     }).ToListAsync()
                }
            };

            return response ??
            [
                new("Order items not found",StatusJson.Error, StatusCode.NotFound)
                {
                  OrderItem  = []
                }
            ];
        }
    }
}

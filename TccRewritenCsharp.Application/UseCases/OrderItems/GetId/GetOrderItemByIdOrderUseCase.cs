using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.GetId
{
    public class GetOrderItemByIdOrderUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseGetOrderItemsJson> Execute(Guid id)
        {

            Util.Validate(id);

            var response = new ResponseGetOrderItemsJson("", StatusJson.Success, StatusCode.Ok)
            {
                OrderItem = await _dbContext.OrderItem.Where(x => x.Id == id).Select(x => new OrderItemJson
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Total = x.Total,
                    UnitaryValue = x.UnitaryValue
                }).ToListAsync()
            };

            return response ?? new ResponseGetOrderItemsJson("Order Item not found", StatusJson.Error, StatusCode.NotFound);

        }
    }
}

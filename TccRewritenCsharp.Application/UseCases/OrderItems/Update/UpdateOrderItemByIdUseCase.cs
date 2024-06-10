using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.OrderItems;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Update
{
    public class UpdateOrderItemByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseOrderItemsIdJson> Execute(Guid orderItemId, RequestOrderItemsJson request)
        {
            Util.Validate(request);

            var orderItem = await _dbContext.OrderItem.FirstOrDefaultAsync(x => x.Id == orderItemId);
            if (orderItem != null)
            {
                orderItem.Quantity = request.Quantity;
                orderItem.UnitaryValue = request.UnitaryValue;
                orderItem.Total = request.Total;
                orderItem.ProductId = request.ProductId;
                orderItem.UpdatedAt = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                return new ResponseOrderItemsIdJson
                {
                    Id = orderItem.Id
                };
            }
            else
            {
                throw new Exception("Order Item not found");
            }
        }
    }
}

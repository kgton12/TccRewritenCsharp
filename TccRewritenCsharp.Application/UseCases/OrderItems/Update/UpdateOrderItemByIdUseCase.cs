using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.OrderItems;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Update
{
    public class UpdateOrderItemByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(Guid orderItemId, RequestOrderItemsJson request)
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

                return new ResponseIdJson("", StatusJson.Success, StatusCode.Ok)
                {
                    Id = orderItem.Id
                };
            }
            else
            {
                return new ResponseIdJson("Order item does not exist", StatusJson.Error, StatusCode.NotFound);
            }
        }
    }
}

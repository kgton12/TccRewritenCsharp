using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Delete
{
    public class DeleteOrderItemsByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(Guid id)
        {
            var orderItem = await _dbContext.OrderItem.FirstOrDefaultAsync(x => x.Id == id);

            if (orderItem != null)
            {
                _dbContext.OrderItem.Remove(orderItem);
                await _dbContext.SaveChangesAsync();
                return new ResponseIdJson("Order item deleted successfully", StatusJson.Success, StatusCode.Ok)
                {
                    Id = orderItem.Id
                };
            }
            else
            {
                return new ResponseIdJson("Order item not found", StatusJson.Error, StatusCode.NotFound);
            }
        }
    }
}

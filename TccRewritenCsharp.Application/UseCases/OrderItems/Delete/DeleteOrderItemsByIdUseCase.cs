using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Delete
{
    public class DeleteOrderItemsByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseOrderItemsIdJson> Execute(Guid id)
        {
            var orderItem = await _dbContext.OrderItem.FirstOrDefaultAsync(x => x.Id == id);

            if (orderItem != null)
            {
                _dbContext.OrderItem.Remove(orderItem);
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

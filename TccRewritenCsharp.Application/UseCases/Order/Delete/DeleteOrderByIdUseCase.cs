using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Order.Delete
{
    public class DeleteOrderByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseOrderIdJson> Execute(Guid id)
        {
            var order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                _dbContext.Order.Remove(order);
                await _dbContext.SaveChangesAsync();
                return new ResponseOrderIdJson
                {
                    Id = order.Id
                };
            }
            else
            {
                throw new Exception("Order not found");
            }
        }
    }
}

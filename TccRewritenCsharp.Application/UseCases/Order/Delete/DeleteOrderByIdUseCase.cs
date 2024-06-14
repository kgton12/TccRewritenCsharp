using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Order.Delete
{
    public class DeleteOrderByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(Guid id)
        {
            var order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                _dbContext.Order.Remove(order);
                await _dbContext.SaveChangesAsync();
                return new ResponseIdJson("", StatusJson.Success, StatusCode.Ok)
                {
                    Id = order.Id
                };
            }
            else
            {
                return new ResponseIdJson("Order not found", StatusJson.Error, StatusCode.NotFound);
            }
        }
    }
}

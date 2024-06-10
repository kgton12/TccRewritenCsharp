using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Order.Update
{
    public class UpdateOrderByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseOrderIdJson> Execute(Guid id, RequestOrderJson request)
        {
            var validate = new Util();

            Util.Validate(request);

            var order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                order.Status = request.Status;
                order.Quantity = request.Quantity;
                order.UpdatedAt = DateTime.Now;
                order.UserId = request.UserId;

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

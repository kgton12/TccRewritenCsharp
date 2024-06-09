using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Order.GetId
{
    public class GetOrderByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetOrderByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
        {
            _dbContext = new TccRewritenCsharpDbContext(environment);
        }

        public async Task<ResponseOrderJson> Execute(Guid id)
        {
            var order = await _dbContext.Order.Where(x => x.Id == id).Select(x => new ResponseOrderJson
            {
                Id = x.Id,
                UserId = x.UserId,
                Quantity = x.Quantity,
                Total = x.Total,
                Status = x.Status
            }).FirstOrDefaultAsync();

            return order ?? throw new Exception("Order not found");
        }

    }
}

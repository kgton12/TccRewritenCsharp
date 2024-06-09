using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Order.Get
{
    public class GetOrderUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetOrderUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
        {
            _dbContext = new TccRewritenCsharpDbContext(environment);
        }

        public async Task<List<ResponseOrderJson>> Execute()
        {
            var order = await _dbContext.Order.Select(x => new ResponseOrderJson
            {
                Id = x.Id,
                UserId = x.UserId,
                Quantity = x.Quantity,
                Total = x.Total,
                Status = x.Status
            }).ToListAsync();

            return order ?? throw new Exception("Order not found");
        }
    }
}

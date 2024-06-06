using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Order.GetId
{
    public class GetOrderByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetOrderByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
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

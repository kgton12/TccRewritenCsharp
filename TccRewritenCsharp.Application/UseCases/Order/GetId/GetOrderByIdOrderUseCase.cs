using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Order.GetId
{
    public class GetOrderByIdOrderUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetOrderByIdOrderUseCase()
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

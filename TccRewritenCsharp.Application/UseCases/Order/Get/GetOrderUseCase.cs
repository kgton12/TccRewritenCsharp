using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Entities;

namespace TccRewritenCsharp.Application.UseCases.Order.Get
{
    public class GetOrderUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetOrderUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
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

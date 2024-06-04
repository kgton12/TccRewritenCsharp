using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Delete
{
    public class DeleteOrderItemsByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public DeleteOrderItemsByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public async Task<ResponseOrderIdJson> Execute(Guid id)
        {
            var orderItem = await _dbContext.OrderItem.FirstOrDefaultAsync(x => x.Id == id);

            if (orderItem != null)
            {
                _dbContext.OrderItem.Remove(orderItem);
                await _dbContext.SaveChangesAsync();
                return new ResponseOrderIdJson
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

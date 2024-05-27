using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Order.Delete
{
    public class DeleteOrderByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public DeleteOrderByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public ResponseOrderIdJson Execute(Guid id)
        {
            var order = _dbContext.Order.FirstOrDefault(x => x.Id == id);

            if (order != null)
            {
                _dbContext.Order.Remove(order);
                _dbContext.SaveChanges();
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

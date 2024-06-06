using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Entities;

namespace TccRewritenCsharp.Application.UseCases.Order.GetFull
{
    public class GetFullOrderByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetFullOrderByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }

        public async Task<ResponseFullOrderJson> Execute(Guid id)
        {
            decimal total = 0;

            var order = await _dbContext.Order.Where(x => x.Id == id).FirstOrDefaultAsync();
            var orderItems = await _dbContext.OrderItem.Where(x => x.OrderId == id).ToListAsync();

            if (order == null)
            {
                throw new Exception("Order not found");
            }            

            foreach (var item in orderItems)
            {
                total += item.Quantity * item.UnitaryValue; 
            }

            var response = new ResponseFullOrderJson
            {
                Id = order.Id,
                OrderItems = orderItems.Select(x => new ResponseGetOrderItemsJson
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    Total = x.Quantity * x.UnitaryValue,
                    UnitaryValue = x.UnitaryValue,               
                }).ToList(),
                Total = total,
                Quantity = orderItems.Count,
                Status = order.Status,
                UserId = order.UserId
            };

            return response;
        }
    }
}

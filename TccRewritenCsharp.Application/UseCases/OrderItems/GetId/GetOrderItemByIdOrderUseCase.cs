using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.GetId
{
    public class GetOrderItemByIdOrderUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetOrderItemByIdOrderUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public async Task<ResponseGetOrderItemsJson> Execute(Guid id)
        {
            var orderItem = await _dbContext.OrderItem.Where(x => x.Id == id).Select(x => new ResponseGetOrderItemsJson
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                Total = x.Total,
                UnitaryValue = x.UnitaryValue                
            }).FirstOrDefaultAsync();

            return orderItem ?? throw new Exception("Order Item not found");
        }
    }
}

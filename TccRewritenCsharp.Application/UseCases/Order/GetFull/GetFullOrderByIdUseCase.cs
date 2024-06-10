using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Order.GetFull
{
    public class GetFullOrderByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

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

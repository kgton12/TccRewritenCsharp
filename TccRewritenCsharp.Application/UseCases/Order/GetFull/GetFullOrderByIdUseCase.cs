using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response;
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
            var validId = Util.ValidateId(id);

            if (validId.IsValid == false)
                return new ResponseFullOrderJson(validId.Message, StatusJson.Error, StatusCode.BadRequest);

            decimal total = 0;

            var order = await _dbContext.Order.Where(x => x.Id == id).FirstOrDefaultAsync();
            var orderItems = await _dbContext.OrderItem.Where(x => x.OrderId == id).ToListAsync();

            if (order == null)
            {
                return new ResponseFullOrderJson("Order not found", StatusJson.Error, StatusCode.NotFound) { };
            }

            foreach (var item in orderItems)
            {
                total += item.Quantity * item.UnitaryValue;
            }

            var response = new ResponseFullOrderJson("", StatusJson.Success, StatusCode.Ok)
            {
                Id = order.Id,
                UserId = order.UserId,
                Quantity = orderItems.Count,
                Total = total,
                Status = order.Status,
                OrderItems = await _dbContext.OrderItem.Where(x => x.Id == id).Select(x => new OrderItemJson
                {
                    Id = x.Id,
                    OrderId = x.OrderId,
                    ProductId = x.ProductId,
                    Quantity = x.Quantity,
                    UnitaryValue = x.UnitaryValue,
                    Total = x.Quantity * x.UnitaryValue
                }).ToListAsync()
            };

            return response ?? new ResponseFullOrderJson("Order not found", StatusJson.Error, StatusCode.NotFound) { };
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.OrderItems;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Entities;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Register
{
    public class RegisterOrderItemsUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseOrderItemsIdJson> Execute(RequestOrderItemsJson request)
        {
            Util.Validate(request);

            var orderItemsExists = await _dbContext.OrderItem.AnyAsync(x => x.OrderId == request.OrderId && x.ProductId == request.ProductId);

            if (orderItemsExists)
            {
                throw new Exception("Order or product does not exist");
            }

            var orderItems = new OrderItem
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Total = request.Total,
                UnitaryValue = request.UnitaryValue,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _dbContext.OrderItem.Add(orderItems);
            await _dbContext.SaveChangesAsync();
            return new ResponseOrderItemsIdJson
            {
                Id = orderItems.Id
            };
        }
    }
}

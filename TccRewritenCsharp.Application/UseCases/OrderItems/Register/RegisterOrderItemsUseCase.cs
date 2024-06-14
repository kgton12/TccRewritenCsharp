using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.OrderItems;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Entities;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Register
{
    public class RegisterOrderItemsUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(RequestOrderItemsJson request)
        {
            Util.Validate(request);

            var orderItemsExists = await _dbContext.OrderItem.AnyAsync(x => x.OrderId == request.OrderId && x.ProductId == request.ProductId);

            if (orderItemsExists)
            {
                return new ResponseIdJson("Order item already exists", StatusJson.Error, StatusCode.BadRequest);
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
            return new ResponseIdJson("Order item registered successfully", StatusJson.Success, StatusCode.Ok)
            {
                Id = orderItems.Id
            };
        }
    }
}

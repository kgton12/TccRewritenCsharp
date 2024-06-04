using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.OrderItems;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Entities;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Register
{
    public class RegisterOrderItemsUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public RegisterOrderItemsUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public async Task<ResponseOrderItemsIdJson> Execute(RequestOrderItemsJson request)
        {
            var validate = new Util();
            validate.Validate(request);

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

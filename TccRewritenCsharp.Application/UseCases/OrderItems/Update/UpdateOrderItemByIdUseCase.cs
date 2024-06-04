using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Requests.OrderItems;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Entities;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Update
{
    public class UpdateOrderItemByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public UpdateOrderItemByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public async Task<ResponseOrderIdJson> Execute(Guid orderItemId, RequestOrderItemsJson request)
        {
            var validate = new Util();

            validate.Validate(request);

            var orderItem = await _dbContext.OrderItem.FirstOrDefaultAsync(x => x.Id == orderItemId);
            if (orderItem != null)
            {
                orderItem.Quantity = request.Quantity;
                orderItem.UnitaryValue = request.UnitaryValue;
                orderItem.Total = request.Total;
                orderItem.ProductId = request.ProductId;
                orderItem.UpdatedAt = DateTime.Now;

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

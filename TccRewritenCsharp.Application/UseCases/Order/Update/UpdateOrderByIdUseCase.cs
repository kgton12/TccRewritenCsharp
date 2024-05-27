﻿using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Order.Update
{
    public class UpdateOrderByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public UpdateOrderByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }

        public async Task<ResponseOrderIdJson> Execute(Guid id, RequestOrderJson request)
        {
            var order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                order.Status = request.Status;
                order.Total = request.Total;
                order.Quantity = request.Quantity;
                order.UpdatedAt = DateTime.Now;
                order.UserId = request.UserId;

                await _dbContext.SaveChangesAsync();

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

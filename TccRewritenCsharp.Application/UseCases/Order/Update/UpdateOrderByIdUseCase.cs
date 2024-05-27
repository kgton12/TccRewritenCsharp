﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Communication.Response.Product;
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

        public ResponseOrderIdJson Execute(Guid id, RequestOrderJson request)
        {
            var order = _dbContext.Order.FirstOrDefault(x => x.Id == id);

            if (order != null)
            {
                order.Status = request.Status;
                order.Total = request.Total;
                order.Quantity = request.Quantity;
                order.UpdatedAt = DateTime.Now;
                order.UserId = request.UserId;

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
﻿using Microsoft.AspNetCore.Mvc;
using TccRewritenCsharp.Application.UseCases.Order.Delete;
using TccRewritenCsharp.Application.UseCases.Order.Get;
using TccRewritenCsharp.Application.UseCases.Order.GetId;
using TccRewritenCsharp.Application.UseCases.Order.Register;
using TccRewritenCsharp.Application.UseCases.Order.Update;
using TccRewritenCsharp.Application.UseCases.Product.Update;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure.Entities;

namespace TccRewritenCsharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseOrderJson>>> GetOrder()
        {
            var useCase = new GetOrderUseCase();

            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseOrderJson>> GetOrderById(Guid id)
        {
            var useCase = new GetOrderByIdOrderUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseOrderIdJson>> UpdateOrderById(Guid id, RequestOrderJson request)
        {
            var useCase = new UpdateOrderByIdUseCase();

            var response = await useCase.Execute(id, request);

            return Ok(response);            
        }

        [HttpPost]
        public async Task<ActionResult<ResponseOrderIdJson>> RegisterOrder(RequestOrderJson request)
        {
            var useCase = new RegisterOrderUseCase();

            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseOrderIdJson>> DeleteOrderById(Guid id)
        {
            var useCase = new DeleteOrderByIdUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);

        }
    }
}

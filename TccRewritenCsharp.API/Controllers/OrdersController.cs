using Microsoft.AspNetCore.Mvc;
using TccRewritenCsharp.Application.UseCases.Order.Delete;
using TccRewritenCsharp.Application.UseCases.Order.Get;
using TccRewritenCsharp.Application.UseCases.Order.GetFull;
using TccRewritenCsharp.Application.UseCases.Order.GetId;
using TccRewritenCsharp.Application.UseCases.Order.Register;
using TccRewritenCsharp.Application.UseCases.Order.Update;
using TccRewritenCsharp.Communication.Requests.Order;

namespace TccRewritenCsharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetOrder()
        {
            var useCase = new GetOrderUseCase();

            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderById(Guid id)
        {
            var useCase = new GetOrderByIdUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);
        }
        [HttpGet("fullorder/{id}")]
        public async Task<ActionResult> GetFullOrderById(Guid id)
        {
            var useCase = new GetFullOrderByIdUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderById(Guid id, RequestOrderJson request)
        {
            var useCase = new UpdateOrderByIdUseCase();

            var response = await useCase.Execute(id, request);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterOrder(RequestOrderJson request)
        {
            var useCase = new RegisterOrderUseCase();

            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrderById(Guid id)
        {
            var useCase = new DeleteOrderByIdUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);

        }
    }
}

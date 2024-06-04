using Microsoft.AspNetCore.Mvc;
using TccRewritenCsharp.Application.UseCases.OrderItems.Delete;
using TccRewritenCsharp.Application.UseCases.OrderItems.Get;
using TccRewritenCsharp.Application.UseCases.OrderItems.GetId;
using TccRewritenCsharp.Application.UseCases.OrderItems.Register;
using TccRewritenCsharp.Application.UseCases.OrderItems.Update;
using TccRewritenCsharp.Communication.Requests.OrderItems;
using TccRewritenCsharp.Infrastructure.Entities;

namespace TccRewritenCsharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        // GET: api/OrderItems
        [HttpGet("/api/Order/OrderItems/{idOrder}")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetFullOrder(Guid idOrder)
        {
            var useCase = new GetFullOrderItemUseCase();

            var response = await useCase.Execute(idOrder);

            return Ok(response);
        }

        // GET: api/OrderItems/5
        [HttpGet("{idOrdemItem}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(Guid idOrdemItem)
        {
            var useCase = new GetOrderItemByIdOrderUseCase();

            var response = await useCase.Execute(idOrdemItem);

            return Ok(response);
        }

        // PUT: api/OrderItems/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OrderItem>> PutOrderItem(Guid id, [FromBody] RequestOrderItemsJson orderItem)
        {
            var useCase = new UpdateOrderItemByIdUseCase();

            var response = await useCase.Execute(id, orderItem);

            return Ok(response);
        }

        // POST: api/OrderItems
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem([FromBody] RequestOrderItemsJson request)
        {
            var useCase = new RegisterOrderItemsUseCase();

            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(Guid id)
        {
            var useCase = new DeleteOrderItemsByIdUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);
        }
    }
}

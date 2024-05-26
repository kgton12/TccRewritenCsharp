using Microsoft.AspNetCore.Mvc;
using TccRewritenCsharp.Application.UseCases.Order.Register;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Infrastructure.Entities;

namespace TccRewritenCsharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder()
        {
            return Ok();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(Guid id)
        {
            return Ok();
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(Guid id, Order order)
        {


            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult RegisterOrder(RequestOrderJson request)
        {
            var useCase = new RegisterOrderUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            return Ok();
        }
    }
}

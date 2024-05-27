using Microsoft.AspNetCore.Mvc;
using TccRewritenCsharp.Application.UseCases.Order.Delete;
using TccRewritenCsharp.Application.UseCases.Order.Get;
using TccRewritenCsharp.Application.UseCases.Order.GetId;
using TccRewritenCsharp.Application.UseCases.Order.Register;
using TccRewritenCsharp.Application.UseCases.Order.Update;
using TccRewritenCsharp.Application.UseCases.Product.Update;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Infrastructure.Entities;

namespace TccRewritenCsharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetOrder()
        {
            var useCase = new GetOrderUseCase();

            var response = useCase.Execute();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult GetOrderById(Guid id)
        {
            var useCase = new GetOrderByIdOrderUseCase();

            var response = useCase.Execute(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateOrderById(Guid id, RequestOrderJson request)
        {
            var useCase = new UpdateOrderByIdUseCase();

            var response = useCase.Execute(id, request);

            return Ok(response);            
        }

        [HttpPost]
        public ActionResult RegisterOrder(RequestOrderJson request)
        {
            var useCase = new RegisterOrderUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteOrderById(Guid id)
        {
            var useCase = new DeleteOrderByIdUseCase();

            var response = useCase.Execute(id);

            return Ok(response);

        }
    }
}

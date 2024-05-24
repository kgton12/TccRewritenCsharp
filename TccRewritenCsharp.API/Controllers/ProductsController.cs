using Microsoft.AspNetCore.Mvc;
using TccRewritenCsharp.Application.UseCases.Product.Delete;
using TccRewritenCsharp.Application.UseCases.Product.Get;
using TccRewritenCsharp.Application.UseCases.Product.GetId;
using TccRewritenCsharp.Application.UseCases.Product.Register;
using TccRewritenCsharp.Application.UseCases.Product.Update;
using TccRewritenCsharp.Communication.Requests.Product;

namespace TccRewritenCsharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetProduct()
        {
            var useCase = new GetProductUseCase();

            var response = useCase.Execute();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public ActionResult GetProductById([FromRoute] Guid id)
        {
            var useCase = new GetProductByIdUseCase();

            var response = useCase.Execute(id);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProductById([FromRoute] Guid id, [FromBody] RequestProductJson request)
        {
            var useCase = new UpdateProductByIdUseCase();

            var response = useCase.Execute(id, request);

            return Ok(response);
        }

        [HttpPost]
        public ActionResult RegisterProduct([FromBody] RequestProductJson request)
        {
            var useCase = new RegisterProductUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProductById(Guid id)
        {
            var useCase = new DeleteProductByIdUseCase();

            var response = useCase.Execute(id);

            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TccRewritenCsharp.Application.UseCases.Category.Delete;
using TccRewritenCsharp.Application.UseCases.Category.Get;
using TccRewritenCsharp.Application.UseCases.Category.GetId;
using TccRewritenCsharp.Application.UseCases.Category.Register;
using TccRewritenCsharp.Application.UseCases.Category.Update;
using TccRewritenCsharp.Communication.Requests.Category;
using TccRewritenCsharp.Communication.Response.Category;

namespace TccRewritenCsharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult> GetCategory()
        {
            var useCase = new GetCategoryUseCase();

            var response = await useCase.Execute();

            return Ok(response);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCategory(Guid id)
        {
            var useCase = new GetCategoryrByIdUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrderById(Guid id, RequestCategoryJson request)
        {
            var useCase = new UpdateCategoryByIdUseCase();

            var response = await useCase.Execute(id, request);

            return Ok(response);
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult> RegisterCategory(RequestCategoryJson request)
        {

            var useCase = new RegisterCategoryUseCase();

            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(Guid id)
        {
            var useCase = new DeleteCategoryByIdUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);
        }
    }
}

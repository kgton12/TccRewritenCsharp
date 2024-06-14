using Microsoft.AspNetCore.Mvc;
using TccRewritenCsharp.Application.UseCases.User.Delete;
using TccRewritenCsharp.Application.UseCases.User.Get;
using TccRewritenCsharp.Application.UseCases.User.GetId;
using TccRewritenCsharp.Application.UseCases.User.Register;
using TccRewritenCsharp.Application.UseCases.User.Update;
using TccRewritenCsharp.Communication.Requests.User;


namespace TccRewritenCsharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetUser()
        {
            var useCase = new GetUserUseCase();

            var response = await useCase.Execute();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUserById(Guid id)
        {
            var useCase = new GetUserByIdUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> RegisterUser([FromBody] RequestUserJson request)
        {
            var useCase = new RegisterUserUseCase();

            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserById([FromRoute] Guid id, [FromBody] RequestUserJson request)
        {
            var useCase = new UpdateUserByIdUseCase();

            var response = await useCase.Execute(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserById(Guid id)
        {
            var useCase = new DeleteUserByIdUseCase();

            var response = await useCase.Execute(id);

            return Ok(response);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TccRewritenCsharp.Application.UseCases.User.Delete;
using TccRewritenCsharp.Application.UseCases.User.Get;
using TccRewritenCsharp.Application.UseCases.User.GetId;
using TccRewritenCsharp.Application.UseCases.User.Register;
using TccRewritenCsharp.Application.UseCases.User.Update;
using TccRewritenCsharp.Communication.Requests;

namespace TccRewritenCsharp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetUser()
        {
            var useCase = new GetUserUseCase();

            var response = useCase.Execute();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var useCase = new GetUserByIdUseCase();

            var response = useCase.Execute(id);

            return Ok(response);
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] RequestUserJson request)
        {
            var useCase = new RegisterUserUseCase();

            var response = useCase.Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUserById([FromRoute] Guid id, [FromBody] RequestUserJson request)
        {
            var useCase = new UpdateUserByIdUseCase();

            var response = useCase.Execute(id, request);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(Guid id)
        {
            var useCase = new DeleteUserByIdUseCase();

            var response = useCase.Execute(id);

            return Ok(response);
        }
    }
}

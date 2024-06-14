using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.User.Delete
{
    public class DeleteUserByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(Guid id)
        {
            Util.Validate(id);

            var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _dbContext.User.Remove(user);
                await _dbContext.SaveChangesAsync();
                return new ResponseIdJson("User successfully deleted", StatusJson.Success, StatusCode.Ok)
                {
                    Id = user.Id
                };
            }
            else
            {
                return new ResponseIdJson("User not found", StatusJson.Error, 404);
            }
        }

    }
}

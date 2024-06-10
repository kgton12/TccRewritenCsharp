using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.User.Delete
{
    public class DeleteUserByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseUserIdJson> Execute(Guid id)
        {
            Util.Validate(id);

            var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                _dbContext.User.Remove(user);
                await _dbContext.SaveChangesAsync();
                return new ResponseUserIdJson
                {
                    Id = user.Id
                };
            }
            else
            {
                throw new Exception("User not found");
            }
        }

    }
}

using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.User.Delete
{
    public class DeleteUserByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public DeleteUserByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }

        public async Task<ResponseUserIdJson> Execute(Guid id)
        {
            var validate = new Util();

            validate.Validate(id);

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

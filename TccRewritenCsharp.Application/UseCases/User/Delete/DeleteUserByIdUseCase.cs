using TccRewritenCsharp.Communication.Response;
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

        public ResponseUserIdJson Execute(Guid id)
        {
            var user = _dbContext.User.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                _dbContext.User.Remove(user);
                _dbContext.SaveChanges();
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

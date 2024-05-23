using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.User.GetId
{
    public class GetUserByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetUserByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public ResponseGetUserJson Execute(Guid id)
        {
            var user = _dbContext.User.Where(x => x.Id == id).Select(x => new ResponseGetUserJson
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Login = x.Login,
                PassWord = x.PassWord,
                Email = x.Email,
                Admin = x.Admin,
                Telephone = x.Telephone
            }).FirstOrDefault();

            return user ?? throw new Exception("User not found");
        }
    }
}

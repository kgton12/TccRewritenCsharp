using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {

        private readonly TccRewritenCsharpDbContext _dbContext;
        public RegisterUserUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }

        public ResponseUserIdJson Execute(RequestUserJson request)
        {
            var validate = new Util();

            validate.Validate(request);

            var userExists = _dbContext.User.Any(x => x.Login == request.Login && x.Email == request.Email);

            if (userExists)
            {
                throw new Exception("User already exists");
            }

            var user = new Infrastructure.Entities.User
            {
                Name = request.Name,
                LastName = request.LastName,
                Login = request.Login,
                PassWord = request.PassWord,
                Email = request.Email,
                Admin = request.Admin,
                Telephone = request.Telephone,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _dbContext.User.Add(user);
            _dbContext.SaveChanges();

            return new ResponseUserIdJson
            {
                Id = user.Id
            };
        }
    }
}

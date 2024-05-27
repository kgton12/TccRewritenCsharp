using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.User;
using TccRewritenCsharp.Communication.Response.User;
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

        public async Task<ResponseUserIdJson> Execute(RequestUserJson request)
        {
            var validate = new Util();
            validate.Validate(request);

            var userExists = await _dbContext.User.AnyAsync(x => x.Login == request.Login && x.Email == request.Email);

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
                UpdatedAt = DateTime.Now,
                Address = request.Address,
                City = request.City,
                State = request.State,
                Country = request.Country,
                ZipCode = request.ZipCode,
                Number = request.Number
            };

            _dbContext.User.Add(user);
            await _dbContext.SaveChangesAsync();

            return new ResponseUserIdJson
            {
                Id = user.Id
            };
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.User;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.User.Register
{
    public class RegisterUserUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(RequestUserJson request)
        {
            var valid = Util.Validate(request);

            if (Util.Validate(request).IsValid == false)
                return new ResponseIdJson(valid.Message, StatusJson.Error, StatusCode.BadRequest);


            var userExists = await _dbContext.User.AnyAsync(x => x.Login == request.Login && x.Email == request.Email);

            if (userExists)
            {
                return new ResponseIdJson("User already exists", StatusJson.Error, StatusCode.BadRequest);
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

            return new ResponseIdJson("Successfully created", StatusJson.Success, StatusCode.Ok)
            {
                Id = user.Id
            };
        }
    }
}

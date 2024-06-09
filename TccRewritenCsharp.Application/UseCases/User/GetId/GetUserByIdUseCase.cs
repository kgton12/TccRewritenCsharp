using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.User.GetId
{
    public class GetUserByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetUserByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
        {
            _dbContext = new TccRewritenCsharpDbContext(environment);
        }

        public async Task<ResponseOrderUserJson> Execute(Guid id)
        {
            var validate = new Util();

            validate.Validate(id);

            var user = await _dbContext.User.Where(x => x.Id == id).Select(x => new ResponseOrderUserJson
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Login = x.Login,
                PassWord = x.PassWord,
                Email = x.Email,
                Admin = x.Admin,
                Telephone = x.Telephone,
                Address = x.Address,
                City = x.City,
                State = x.State,
                Country = x.Country,
                ZipCode = x.ZipCode,
                Number = x.Number
            }).FirstOrDefaultAsync();

            return user ?? throw new Exception("User not found");
        }
    }
}

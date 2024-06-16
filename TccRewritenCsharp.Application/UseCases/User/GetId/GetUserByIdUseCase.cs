using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.User.GetId
{
    public class GetUserByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseUserJson> Execute(Guid id)
        {
            var validId = Util.ValidateId(id);

            if (validId.IsValid == false)
                return new ResponseUserJson(validId.Message, StatusJson.Error, StatusCode.NotFound);


            var response = new ResponseUserJson("", StatusJson.Success, StatusCode.Ok)
            {
                User = await _dbContext.User.Where(x => x.Id == id).Select(x => new UserJson
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
                }).FirstOrDefaultAsync()
            };

            return response ?? new ResponseUserJson("User not found", StatusJson.Error, StatusCode.NotFound);
        }
    }
}

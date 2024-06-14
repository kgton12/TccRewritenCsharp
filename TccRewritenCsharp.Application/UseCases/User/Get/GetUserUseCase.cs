using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.User.Get
{
    public class GetUserUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<List<ResponseAllGetUserJson>> Execute()
        {
            var response = new List<ResponseAllGetUserJson>()
            {
                new("",StatusJson.Success, StatusCode.Ok)
                {
                    Users = await _dbContext.User.Select(x => new UserJson
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
                     }).ToListAsync()
                }
            };

            return response ??
            [
                new("User not found",StatusJson.Error, StatusCode.NotFound)
                {
                    Users = []
                }
            ];
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.User;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.User.Update
{
    public class UpdateUserByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(Guid id, RequestUserJson request)
        {
            Util.Validate(request);

            var user = await _dbContext.User.FirstOrDefaultAsync(x => x.Id == id);

            if (user != null)
            {
                user.Name = request.Name;
                user.LastName = request.LastName;
                user.Login = request.Login;
                user.PassWord = request.PassWord;
                user.Email = request.Email;
                user.Admin = request.Admin;
                user.Telephone = request.Telephone;
                user.UpdatedAt = DateTime.Now;
                user.Address = request.Address;
                user.City = request.City;
                user.State = request.State;
                user.Country = request.Country;
                user.ZipCode = request.ZipCode;
                user.Number = request.Number;

                await _dbContext.SaveChangesAsync();

                return new ResponseIdJson("User updated successfully", StatusJson.Success, StatusCode.Ok)
                {
                    Id = user.Id
                };
            }
            else
            {
                return new ResponseIdJson("User not found", StatusJson.Error, StatusCode.NotFound);
            }
        }
    }
}

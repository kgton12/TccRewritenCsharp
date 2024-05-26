using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.User;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.User.Update
{
    public class UpdateUserByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;

        public UpdateUserByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }

        public ResponseUserIdJson Execute(Guid id, RequestUserJson request)
        {
            var validate = new Util();

            validate.Validate(request);

            var user = _dbContext.User.FirstOrDefault(x => x.Id == id);

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

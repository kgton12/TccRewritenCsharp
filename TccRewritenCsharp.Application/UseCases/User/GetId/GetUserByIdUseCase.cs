using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.User;
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
            var validate = new Util();

            validate.Validate(id);

            var user = _dbContext.User.Where(x => x.Id == id).Select(x => new ResponseGetUserJson
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
            }).FirstOrDefault();

            return user ?? throw new Exception("User not found");
        }
    }
}

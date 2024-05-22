using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.User.Get
{
    public class GetUserUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetUserUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public List<ResponseGetUserJson> Execute()
        {
            var user = _dbContext.User.Select(x => new ResponseGetUserJson
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Login = x.Login,
                PassWord = x.PassWord,
                Email = x.Email,
                Admin = x.Admin,
                Telephone = x.Telephone
            }).ToList();

            return user ?? throw new Exception("User not found");
        }
    }
}

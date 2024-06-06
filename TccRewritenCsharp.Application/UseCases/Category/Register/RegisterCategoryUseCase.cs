using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Category;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Response.Category;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Category.Register
{
    public class RegisterCategoryUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public RegisterCategoryUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public async Task<ResponseCategoryIdJson> Execute(RequestCategoryJson request)
        {
            var validate = new Util();

            validate.Validate(request);

            var category = new Infrastructure.Entities.Category
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _dbContext.Category.Add(category);
            await _dbContext.SaveChangesAsync();

            return new ResponseCategoryIdJson
            {
                Id = category.Id
            };
        }
    }
}

using Microsoft.EntityFrameworkCore;
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

namespace TccRewritenCsharp.Application.UseCases.Category.Update
{
    public class UpdateCategoryByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public UpdateCategoryByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }

        public async Task<ResponseCategoryIdJson> Execute(Guid id, RequestCategoryJson request)
        {
            var validate = new Util();

            validate.Validate(request);

            var category = await _dbContext.Category.FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
            {
                category.Name = request.Name;
                category.Description = request.Description;
                category.UpdatedAt = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                return new ResponseCategoryIdJson
                {
                    Id = category.Id
                };
            }
            else
            {
                throw new Exception("Category not found");
            }
        }
    }
}

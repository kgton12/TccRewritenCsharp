using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Communication.Response.Category;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Category.Delete
{
    public class DeleteCategoryByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public DeleteCategoryByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }

        public async Task<ResponseCategoryIdJson> Execute(Guid id)
        {
            var category = await _dbContext.Category.FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
            {
                _dbContext.Category.Remove(category);
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

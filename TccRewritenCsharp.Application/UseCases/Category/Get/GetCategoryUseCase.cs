using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TccRewritenCsharp.Communication.Response.Category;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Category.Get
{
    public class GetCategoryUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetCategoryUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public async Task<List<ResponseCategoryJson>> Execute()
        {
            var category = await _dbContext.Category.Select(x => new ResponseCategoryJson
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToListAsync();

            return category ?? throw new Exception("Category not found");
        }
    }
}

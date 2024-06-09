using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Category;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Category.Get
{
    public class GetCategoryUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetCategoryUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
        {
            _dbContext = new TccRewritenCsharpDbContext(environment);
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

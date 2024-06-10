using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Category;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Category.Delete
{
    public class DeleteCategoryByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new TccRewritenCsharpDbContext(environment);

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

using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Category;
using TccRewritenCsharp.Communication.Response.Category;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Category.Update
{
    public class UpdateCategoryByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public UpdateCategoryByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
        {
            _dbContext = new TccRewritenCsharpDbContext(environment);
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

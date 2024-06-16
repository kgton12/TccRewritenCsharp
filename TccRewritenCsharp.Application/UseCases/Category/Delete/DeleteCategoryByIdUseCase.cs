using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Category.Delete
{
    public class DeleteCategoryByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(Guid id)
        {
            var validId = Util.ValidateId(id);

            if (validId.IsValid == false)
                return new ResponseIdJson(validId.Message, StatusJson.Error, StatusCode.BadRequest);

            var category = await _dbContext.Category.FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
            {
                _dbContext.Category.Remove(category);
                await _dbContext.SaveChangesAsync();
                return new ResponseIdJson("Category deleted successfully", StatusJson.Success, StatusCode.Ok)
                {
                    Id = category.Id
                };
            }
            else
            {
                return new ResponseIdJson("Category not found", StatusJson.Error, StatusCode.NotFound);
            }
        }
    }
}

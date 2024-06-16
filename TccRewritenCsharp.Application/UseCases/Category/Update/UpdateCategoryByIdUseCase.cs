using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Category;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Category.Update
{
    public class UpdateCategoryByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(Guid id, RequestCategoryJson request)
        {
            var valid = Util.Validate(request);

            if (Util.Validate(request).IsValid == false)
                return new ResponseIdJson(valid.Message, StatusJson.Error, StatusCode.BadRequest);

            var validId = Util.ValidateId(id);

            if (validId.IsValid == false)
                return new ResponseIdJson(validId.Message, StatusJson.Error, StatusCode.BadRequest);

            var category = await _dbContext.Category.FirstOrDefaultAsync(x => x.Id == id);

            if (category != null)
            {
                category.Name = request.Name;
                category.Description = request.Description;
                category.UpdatedAt = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                return new ResponseIdJson("Category updated successfully", StatusJson.Success, StatusCode.Ok)
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

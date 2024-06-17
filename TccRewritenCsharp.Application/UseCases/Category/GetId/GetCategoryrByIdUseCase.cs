using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.Category;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Category.GetId
{
    public class GetCategoryrByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseCategoryJson> Execute(Guid id)
        {
            var validId = Util.ValidateId(id);

            if (validId.IsValid == false)
                return new ResponseCategoryJson(validId.Message, StatusJson.Error, StatusCode.BadRequest);

            var response = new ResponseCategoryJson("", StatusJson.Success, StatusCode.Ok)
            {
                Category = await _dbContext.Category.Where(x => x.Id == id).Select(x => new CategoryJson
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description
                }).FirstOrDefaultAsync()
            };

            return response ?? new ResponseCategoryJson("Category Not Found", StatusJson.Error, StatusCode.NotFound) { Category = null };
        }
    }
}

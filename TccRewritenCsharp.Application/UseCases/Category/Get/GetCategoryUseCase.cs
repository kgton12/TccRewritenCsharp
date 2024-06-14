using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Category;
using TccRewritenCsharp.Communication.Response.User;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Category.Get
{
    public class GetCategoryUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<List<ResponseAllGetCategoryJson>> Execute()
        {
            var response = new List<ResponseAllGetCategoryJson>()
            {
                new("", StatusJson.Success, StatusCode.Ok)
                {
                    Category = await _dbContext.Category.Select(x => new CategoryJson
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description
                    }).ToListAsync()
                }
            };

            return response ??
            [
                new("Category not found",StatusJson.Error, StatusCode.NotFound)
                {
                    Category = []
                }
            ];           
        }
    }
}

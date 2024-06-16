using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Category;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Category.Register
{
    public class RegisterCategoryUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(RequestCategoryJson request)
        {
            var valid = Util.Validate(request);

            if (Util.Validate(request).IsValid == false)
                return new ResponseIdJson(valid.Message, StatusJson.Error, StatusCode.BadRequest);

            var category = new Infrastructure.Entities.Category
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _dbContext.Category.Add(category);
            await _dbContext.SaveChangesAsync();

            return new ResponseIdJson("Category successfully registered", StatusJson.Success, StatusCode.Ok)
            {
                Id = category.Id
            };
        }
    }
}

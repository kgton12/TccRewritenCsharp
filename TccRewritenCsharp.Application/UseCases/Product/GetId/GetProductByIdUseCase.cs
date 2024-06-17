using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.Product;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Product.GetId
{
    public class GetProductByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseGetProductJson> Execute(Guid id)
        {
            var validId = Util.ValidateId(id);

            if (validId.IsValid == false)
                return new ResponseGetProductJson(validId.Message, StatusJson.Error, StatusCode.BadRequest);

            var response = new ResponseGetProductJson("", StatusJson.Success, StatusCode.Ok)
            {
                ProductJson = await _dbContext.Product.Where(x => x.Id == id).Select(x => new ProductJson
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Price = x.Price,
                    Stock = x.Stock,
                    CategoryId = x.CategoryId
                }).FirstOrDefaultAsync()
            };

            return response ?? new ResponseGetProductJson("Product not found", StatusJson.Error, StatusCode.NotFound);
        }
    }
}

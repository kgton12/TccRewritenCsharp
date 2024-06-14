using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Product;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Product.Get
{
    public class GetProductUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<List<ResponseAllGetProductJson>> Execute()
        {

            var response = new List<ResponseAllGetProductJson>()
            {
                new("",StatusJson.Success, StatusCode.Ok)
                {
                    Products = await _dbContext.Product.Select(x => new ProductJson
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        Price = x.Price,
                        Stock = x.Stock,
                        CategoryId = x.CategoryId
                    }).ToListAsync()
                }
            };

            return response ??
             [
                new("Product not found",StatusJson.Error, StatusCode.NotFound)
                {
                    Products = []
                }
             ];
        }
    }
}

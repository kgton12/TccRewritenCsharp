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
            Util.Validate(id);

            var product = await _dbContext.Product.Where(x => x.Id == id).Select(x => new ResponseGetProductJson
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                CategoryId = x.CategoryId
            }).FirstOrDefaultAsync();

            return product ?? throw new Exception("Product not found");
        }
    }
}

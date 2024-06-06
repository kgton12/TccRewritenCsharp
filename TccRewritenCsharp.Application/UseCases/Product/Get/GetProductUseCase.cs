using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Product;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Product.Get
{
    public class GetProductUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetProductUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public async Task<List<ResponseGetProductJson>> Execute()
        {
            var product = await _dbContext.Product.Select(x => new ResponseGetProductJson
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                CategoryId = x.CategoryId
            }).ToListAsync();

            return product ?? throw new Exception("Product not found");
        }
    }
}

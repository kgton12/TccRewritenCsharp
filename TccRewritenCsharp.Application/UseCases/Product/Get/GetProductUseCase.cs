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
        public List<ResponseGetProductJson> Execute()
        {
            var product = _dbContext.Product.Select(x => new ResponseGetProductJson
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                Category = x.Category
            }).ToList();

            return product ?? throw new Exception("Product not found");
        }
    }
}

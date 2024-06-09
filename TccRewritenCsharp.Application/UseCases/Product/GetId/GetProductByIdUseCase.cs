using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.Product;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Product.GetId
{
    public class GetProductByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public GetProductByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
        {
            _dbContext = new TccRewritenCsharpDbContext(environment);
        }

        public async Task<ResponseGetProductJson> Execute(Guid id)
        {
            var validate = new Util();

            validate.Validate(id);

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

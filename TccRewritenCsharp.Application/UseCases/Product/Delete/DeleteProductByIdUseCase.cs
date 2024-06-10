using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.Product;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Product.Delete
{
    public class DeleteProductByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseProductIdJson> Execute(Guid id)
        {
            var validate = new Util();

            Util.Validate(id);
            var product = await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                _dbContext.Product.Remove(product);
                await _dbContext.SaveChangesAsync();
                return new ResponseProductIdJson
                {
                    Id = product.Id
                };
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}

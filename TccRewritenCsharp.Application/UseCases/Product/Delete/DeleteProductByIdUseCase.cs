using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.Product;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Product.Delete
{
    public class DeleteProductByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public DeleteProductByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }

        public async Task<ResponseProductIdJson> Execute(Guid id)
        {
            var validate = new Util();

            validate.Validate(id);
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

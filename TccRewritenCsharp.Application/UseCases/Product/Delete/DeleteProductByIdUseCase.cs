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
        public ResponseProductIdJson Execute(Guid id)
        {
            var product = _dbContext.Product.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                _dbContext.Product.Remove(product);
                _dbContext.SaveChanges();
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

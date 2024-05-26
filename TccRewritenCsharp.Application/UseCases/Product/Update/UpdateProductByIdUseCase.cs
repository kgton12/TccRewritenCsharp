using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Product;
using TccRewritenCsharp.Communication.Response.Product;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Product.Update
{
    public class UpdateProductByIdUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;

        public UpdateProductByIdUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public ResponseProductIdJson Execute(Guid id, RequestProductJson request)
        {
            var validate = new Util();

            validate.Validate(id);
            validate.Validate(request);

            var product = _dbContext.Product.FirstOrDefault(x => x.Id == id);

            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Stock = request.Stock;
                product.Image = request.Image;
                product.Category = request.Category;
                product.UpdatedAt = DateTime.Now;

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

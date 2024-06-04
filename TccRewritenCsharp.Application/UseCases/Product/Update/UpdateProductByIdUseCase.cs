using Microsoft.EntityFrameworkCore;
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

        public async Task<ResponseProductIdJson> Execute(Guid id, RequestProductJson request)
        {
            var validate = new Util();

            validate.Validate(request);

            var product = await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Stock = request.Stock;
                product.Image = request.Image;
                product.Category = request.Category;
                product.UpdatedAt = DateTime.Now;

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

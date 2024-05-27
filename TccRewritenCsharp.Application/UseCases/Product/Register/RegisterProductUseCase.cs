using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Product;
using TccRewritenCsharp.Communication.Response.Product;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Product.Register
{
    public class RegisterProductUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public RegisterProductUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }

        public async Task<ResponseProductIdJson> Execute(RequestProductJson request)
        {
            var validate = new Util();

            validate.Validate(request);

            var productExists = await _dbContext.Product.AnyAsync(x => x.Name == request.Name);

            if (productExists)
            {
                throw new Exception("Product already exists");
            }

            var product = new Infrastructure.Entities.Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                Category = request.Category,
                Image = request.Image,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _dbContext.Product.Add(product);
            await _dbContext.SaveChangesAsync();

            return new ResponseProductIdJson
            {
                Id = product.Id
            };
        }
    }
}

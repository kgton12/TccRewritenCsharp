using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Product;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Product.Register
{
    public class RegisterProductUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(RequestProductJson request)
        {
            Util.Validate(request);

            var productExists = await _dbContext.Product.AnyAsync(x => x.Name == request.Name);

            if (productExists)
            {
                return new ResponseIdJson("Product already exists", StatusJson.Error, StatusCode.BadRequest);
            }

            var product = new Infrastructure.Entities.Product
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                Stock = request.Stock,
                CategoryId = request.CategoryId,
                Image = request.Image,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _dbContext.Product.Add(product);
            await _dbContext.SaveChangesAsync();

            return new ResponseIdJson("", StatusJson.Success, StatusCode.Ok)
            {
                Id = product.Id
            };
        }
    }
}

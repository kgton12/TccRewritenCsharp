using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Product;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Product.Update
{
    public class UpdateProductByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(Guid id, RequestProductJson request)
        {
            Util.Validate(request);

            var product = await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                product.Stock = request.Stock;
                product.Image = request.Image;
                product.CategoryId = request.CategoryId;
                product.UpdatedAt = DateTime.Now;

                await _dbContext.SaveChangesAsync();
                return new ResponseIdJson("", StatusJson.Success, StatusCode.Ok)
                {
                    Id = product.Id
                };
            }
            else
            {
                return new ResponseIdJson("Product not found", StatusJson.Error, StatusCode.NotFound);
            }
        }
    }
}

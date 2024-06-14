using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Product.Delete
{
    public class DeleteProductByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(Guid id)
        {
            Util.Validate(id);
            var product = await _dbContext.Product.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                _dbContext.Product.Remove(product);
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

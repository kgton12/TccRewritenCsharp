using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.User;
using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.OrderItems.Register
{
    public class RegisterOrderItemsUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public RegisterOrderItemsUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }
        public async Task<ResponseOrderItemsIdJson> Execute(RequestUserJson request)
        {
            var validate = new Util();
            validate.Validate(request);

            var orderItemsExists = await _dbContext.OrderItem.AnyAsync(x => x.OrderId == request.OrderId && x.ProductId == request.ProductId);
        }
    }
}

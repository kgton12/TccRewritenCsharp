using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Order.Register
{
    public class RegisterOrderUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseOrderIdJson> Execute(RequestOrderJson request)
        {
            Util.Validate(request);

            var user = await _dbContext.User.FindAsync(request.UserId) ?? throw new Exception("User not found");

            var order = new Infrastructure.Entities.Order
            {
                UserId = user.Id,
                Quantity = request.Quantity,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = request.Status
            };

            _dbContext.Order.Add(order);
            await _dbContext.SaveChangesAsync();

            return new ResponseOrderIdJson
            {
                Id = order.Id
            };
        }
    }
}

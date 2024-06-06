using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;

namespace TccRewritenCsharp.Application.UseCases.Order.Register
{
    public class RegisterOrderUseCase
    {
        private readonly TccRewritenCsharpDbContext _dbContext;
        public RegisterOrderUseCase()
        {
            _dbContext = new TccRewritenCsharpDbContext();
        }

        public async Task<ResponseOrderIdJson> Execute(RequestOrderJson request)
        {
            var validate = new Util();

            validate.Validate(request);

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

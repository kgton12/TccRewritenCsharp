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
        public ResponseOrderIdJson Execute(RequestOrderJson request)
        {
            var validate = new Util();

            validate.Validate(request);

            var user = _dbContext.User.Find(request.UserId) ?? throw new Exception("User not found");

            var order = new Infrastructure.Entities.Order
            {
                UserId = user.Id,
                Quantity = request.Quantity,
                Total = request.Total,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Status = request.Status
            };

            _dbContext.Order.Add(order);
            _dbContext.SaveChanges();

            return new ResponseOrderIdJson
            {
                Id = order.Id
            };
        }
    }
}

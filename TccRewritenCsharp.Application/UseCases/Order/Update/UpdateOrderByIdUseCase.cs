using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Requests.Order;
using TccRewritenCsharp.Communication.Response;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Order.Update
{
    public class UpdateOrderByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseIdJson> Execute(Guid id, RequestOrderJson request)
        {
            var valid = Util.Validate(request);

            if (Util.Validate(request).IsValid == false)
                return new ResponseIdJson(valid.Message, StatusJson.Error, StatusCode.BadRequest);

            var validId = Util.ValidateId(id);

            if (validId.IsValid == false)
                return new ResponseIdJson(validId.Message, StatusJson.Error, StatusCode.BadRequest);

            var order = await _dbContext.Order.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                order.Status = request.Status;
                order.Quantity = request.Quantity;
                order.UpdatedAt = DateTime.Now;
                order.UserId = request.UserId;

                await _dbContext.SaveChangesAsync();

                return new ResponseIdJson("", StatusJson.Success, StatusCode.Ok)
                {
                    Id = order.Id
                };
            }
            else
            {
                return new ResponseIdJson("Order not found", StatusJson.Error, StatusCode.NotFound);
            }
        }
    }
}

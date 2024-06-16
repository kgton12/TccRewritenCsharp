using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Application.Utils;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Order.GetId
{
    public class GetOrderByIdUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<ResponseOrderJson> Execute(Guid id)
        {
            var validId = Util.ValidateId(id);

            if (validId.IsValid == false)
                return new ResponseOrderJson(validId.Message, StatusJson.Error, StatusCode.BadRequest);


            var response = new ResponseOrderJson("", StatusJson.Success, StatusCode.Ok)
            {
                Order = await _dbContext.Order.Where(x => x.Id == id).Select(x => new OrderJson
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    Status = x.Status,
                    Total = x.Total,
                    UserId = x.UserId
                }).ToListAsync()
            };

            return response ?? new ResponseOrderJson("Order not found", StatusJson.Error, StatusCode.NotFound) { Order = null };
        }

    }
}

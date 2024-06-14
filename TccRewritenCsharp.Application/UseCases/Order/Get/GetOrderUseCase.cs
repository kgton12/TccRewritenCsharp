using Microsoft.EntityFrameworkCore;
using TccRewritenCsharp.Communication.Response.Order;
using TccRewritenCsharp.Infrastructure;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Application.UseCases.Order.Get
{
    public class GetOrderUseCase(ServiceEnvironment environment = ServiceEnvironment.Production)
    {
        private readonly TccRewritenCsharpDbContext _dbContext = new(environment);

        public async Task<List<ResponseOrderJson>> Execute()
        {

            var response = new List<ResponseOrderJson>()
            {
                new("",StatusJson.Success, StatusCode.Ok)
                {
                    Order = await _dbContext.Order.Select(x => new OrderJson
                    {
                        Id = x.Id,
                        UserId = x.UserId,
                        Quantity = x.Quantity,
                        Total = x.Total,
                        Status = x.Status
                     }).ToListAsync()
                }
            };

            return response ??
            [
                new("Order not found",StatusJson.Error, StatusCode.NotFound)
                {
                    Order = []
                }
            ];
        }
    }
}

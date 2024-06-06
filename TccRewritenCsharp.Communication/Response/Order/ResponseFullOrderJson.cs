using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Communication.Response.Order
{
    public class ResponseFullOrderJson
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public Status Status { get; set; }
        public List<ResponseGetOrderItemsJson> OrderItems { get; set; } = null!;
    }
}

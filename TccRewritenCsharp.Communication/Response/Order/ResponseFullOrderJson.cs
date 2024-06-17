using TccRewritenCsharp.Communication.Response.OrderItems;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Communication.Response.Order
{
    public class ResponseFullOrderJson(string message, string status, int statusCode) : ResponseDefaultJson(message, status, statusCode)
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public Status StatusOrder { get; set; }
        public List<OrderItemJson> OrderItems { get; set; } = [];
    }
}

namespace TccRewritenCsharp.Communication.Response.OrderItems
{
    public class ResponseGetOrderItemsJson(string message, string status, int statusCode) : ResponseDefaultJson(message, status, statusCode)
    {
        public List<OrderItemJson>? OrderItem { get; set; }
    }
}

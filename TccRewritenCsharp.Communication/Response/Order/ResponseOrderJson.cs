namespace TccRewritenCsharp.Communication.Response.Order
{
    public class ResponseOrderJson(string message, string status, int statusCode) : ResponseDefaultJson(message, status, statusCode)
    {
        public List<OrderJson>? Order { get; set; } = [];
    }
}

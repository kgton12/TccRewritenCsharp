namespace TccRewritenCsharp.Communication.Response.OrderItems
{
    public class ResponseOrderItemsIdJson(string message, string status, int statusCode) : ResponseIdJson(message, status, statusCode)
    {
    }
}

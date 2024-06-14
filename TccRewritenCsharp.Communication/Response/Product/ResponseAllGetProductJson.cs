
namespace TccRewritenCsharp.Communication.Response.Product
{
    public class ResponseAllGetProductJson(string message, string status, int statusCode) : ResponseDefaultJson(message, status, statusCode)
    {
        public List<ProductJson> Products { get; set; } = [];
    }
}

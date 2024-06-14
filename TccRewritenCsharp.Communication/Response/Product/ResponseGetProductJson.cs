namespace TccRewritenCsharp.Communication.Response.Product
{
    public class ResponseGetProductJson(string message, string status, int statusCode) : ResponseDefaultJson(message, status, statusCode)
    {
        public ProductJson? ProductJson { get; set; }
    }
}

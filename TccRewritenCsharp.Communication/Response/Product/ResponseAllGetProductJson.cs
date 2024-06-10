
namespace TccRewritenCsharp.Communication.Response.Product
{
    public class ResponseAllGetProductJson
    {
        public string Status { get; set; } = string.Empty;
        public List<ResponseGetProductJson> Users { get; set; } = [];
    }
}

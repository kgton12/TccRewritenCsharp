namespace TccRewritenCsharp.Communication.Requests.Product
{
    public class RequestProductJson
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Image { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
    }
}

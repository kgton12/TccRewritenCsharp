namespace TccRewritenCsharp.Communication.Requests.OrderItems
{
    public class RequestOrderItemsJson
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal UnitaryValue { get; set; }
    }
}

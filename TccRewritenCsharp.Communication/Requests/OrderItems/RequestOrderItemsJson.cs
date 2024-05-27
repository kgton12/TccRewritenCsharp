namespace TccRewritenCsharp.Communication.Requests.OrderItems
{
    public class RequestOrderItemsJson
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal UnitaryValue { get; set; }
    }
}

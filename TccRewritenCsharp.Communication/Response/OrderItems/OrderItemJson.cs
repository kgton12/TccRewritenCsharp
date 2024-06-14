namespace TccRewritenCsharp.Communication.Response.OrderItems
{
    public class OrderItemJson
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal UnitaryValue { get; set; }
    }
}

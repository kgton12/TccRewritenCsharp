namespace TccRewritenCsharp.Communication.Response.OrderItems
{
    public class ResponseGetOrderItemsJson
    {
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal UnitaryValue { get; set; }
    }
}

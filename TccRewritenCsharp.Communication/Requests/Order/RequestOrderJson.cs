using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Communication.Requests.Order
{
    public class RequestOrderJson
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public Status Status { get; set; }
    }
}

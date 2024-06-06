using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Communication.Requests.Order
{
    public class RequestOrderJson
    {
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
    }
}

using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Infrastructure.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

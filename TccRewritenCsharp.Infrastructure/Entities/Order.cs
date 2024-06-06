using System.ComponentModel.DataAnnotations.Schema;
using TccRewritenCsharp.Infrastructure.Enums;

namespace TccRewritenCsharp.Infrastructure.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = default!;

        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}

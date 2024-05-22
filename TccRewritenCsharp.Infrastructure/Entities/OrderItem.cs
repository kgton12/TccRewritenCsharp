using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccRewritenCsharp.Infrastructure.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public decimal UnitaryValue { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

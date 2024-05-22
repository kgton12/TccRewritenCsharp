﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccRewritenCsharp.Infrastructure.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

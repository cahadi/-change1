using System;
using System.Collections.Generic;

namespace ООО__Товары_для_животных_.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}

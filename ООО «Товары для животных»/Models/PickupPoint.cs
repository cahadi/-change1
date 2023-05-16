using System;
using System.Collections.Generic;

namespace ООО__Товары_для_животных_.Models
{
    public partial class PickupPoint
    {
        public PickupPoint()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Adress { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}

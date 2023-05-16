using System;
using System.Collections.Generic;

namespace ООО__Товары_для_животных_.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int OrderId { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime OrderDeliveryDate { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderPickupPointId { get; set; }
        public int? UserId { get; set; }
        public int Code { get; set; }

        public virtual PickupPoint OrderPickupPoint { get; set; } = null!;
        public virtual OrderStatus OrderStatus { get; set; } = null!;
        public virtual User? User { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

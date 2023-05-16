using System;
using System.Collections.Generic;

namespace ООО__Товары_для_животных_.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public string ProductArticleNumber { get; set; } = null!;
        public string ProductTitle { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public int ProductCategoryId { get; set; }
        public byte[] ProductPhoto { get; set; } = null!;
        public int ProductManufacturerId { get; set; }
        public decimal ProductCost { get; set; }
        public byte? ProductDiscountAmount { get; set; }
        public int ProductQuantityInStock { get; set; }
        public string? ProductStatus { get; set; }
        public int ProductProviderId { get; set; }
        public byte? ProductMaxDiscount { get; set; }
        public string ProductUnit { get; set; } = null!;

        public virtual Category ProductCategory { get; set; } = null!;
        public virtual Manufacturer ProductManufacturer { get; set; } = null!;
        public virtual Provider ProductProvider { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}

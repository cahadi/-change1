using System;
using System.Collections.Generic;

namespace ООО__Товары_для_животных_.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}

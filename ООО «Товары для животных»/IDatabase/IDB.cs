using System.Collections.Generic;
using System.Linq;
using ООО__Товары_для_животных_.Database;
using ООО__Товары_для_животных_.Models;

namespace ООО__Товары_для_животных_.IDatabase
{
    public interface IDB
    {
        internal static user11Context Instance { get; }
        
        public User GetUsers(string pass, string login);
        
        public List<Manufacturer> GetManufacturersList();

        public void RemoveProduct(Product selectedProduct);

        public int GetCountProduct();

        public IQueryable<Product> SearchProduct(string searchText);

        public IQueryable<Product> FindProductByPM(IQueryable<Product> productsQuery, Manufacturer SelectedManufacturer);
    }
}

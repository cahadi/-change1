using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ООО__Товары_для_животных_.IDatabase;
using ООО__Товары_для_животных_.Models;

namespace ООО__Товары_для_животных_.Database;

public class DB : IDB
{
    private static user11Context _instance;

    internal static user11Context Instance
    {
        get
        {
            _instance ??= new();
            return _instance;
        }
    }

    public User GetUsers(string pass, string login)
    {
        return Instance.Users.Include("UserRoleNavigation")
            .FirstOrDefault(s => s.UserPassword == pass & s.UserLogin == login)!;
    }

    public List<Manufacturer> GetManufacturersList()
    {
        return Instance.Manufacturers.ToList();
    }

    public void RemoveProduct(Product selectedProduct)
    {
        Instance.Products.Remove(selectedProduct);
        Instance.SaveChanges();
    }

    public int GetCountProduct()
    {
        return Instance.Products.Count();
    }

    public IQueryable<Product> SearchProduct(string searchText)
    {
        return Instance.Products
            .Include(p => p.ProductManufacturer)
            .Include(p => p.ProductProvider)
            .Include(p => p.OrderProducts)
            .Include(p => p.ProductCategory)
            .Where(s => s.ProductArticleNumber.Contains(searchText) ||
                s.ProductCategory.Title.Contains(searchText) ||
                s.ProductDescription.Contains(searchText) ||
                s.ProductManufacturer.Title.Contains(searchText) ||
                s.ProductTitle.Contains(searchText) ||
                s.ProductProvider.Title.Contains(searchText));
    }

    public IQueryable<Product> FindProductByPM(IQueryable<Product> productsQuery, Manufacturer SelectedManufacturer)
    {
        return productsQuery.Where(s => s.ProductManufacturerId == SelectedManufacturer.Id);
    }
}
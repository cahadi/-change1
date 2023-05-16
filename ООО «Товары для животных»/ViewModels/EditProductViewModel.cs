using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;
using ООО__Товары_для_животных_.IDatabase;
using ООО__Товары_для_животных_.Models;
using ООО__Товары_для_животных_.Tools;
using ООО__Товары_для_животных_.Views.Pages;

namespace ООО__Товары_для_животных_.ViewModels;

internal class EditProductViewModel : ViewModel
{
    private readonly MainViewModel mainViewModel;
    public Product EditProduct { get; set; }

    public List<Category> Categories { get; set; }
    public List<Provider> Providers { get; set; }
    public List<Manufacturer> Manufacturers { get; set; }

    public Command SelectImage { get; set; }
    public Command RemoveImage { get; set; }
    public Command BackToList { get; set; }
    public Command Save { get; set; }

    public bool CanEditArticle { get; set; }

    private readonly Product original;

    public EditProductViewModel(Product edit, MainViewModel mainViewModel)
    {
        original = edit;

        CanEditArticle = !string.IsNullOrEmpty(edit.ProductArticleNumber);
        var db = IDB.Instance;
        
        Manufacturers = db.Manufacturers.ToList();
        Categories = db.Categories.ToList();
        Providers = db.Providers.ToList();

        EditProduct = new Product
        {
            Image = edit.Image,
            OrderProducts = edit.OrderProducts,
            ProductArticleNumber = edit.ProductArticleNumber,
            ProductCategory = edit.ProductCategory,
            ProductCost = edit.ProductCost,
            ProductDescription = edit.ProductDescription,
            ProductDiscountAmount = edit.ProductDiscountAmount,
            ProductMaxDiscount = edit.ProductMaxDiscount,
            ProductManufacturer = edit.ProductManufacturer,
            ProductTitle = edit.ProductTitle,
            ProductPhoto = edit.ProductPhoto,
            ProductQuantityInStock = edit.ProductQuantityInStock,
            ProductUnit = edit.ProductUnit,
            ProductProvider = edit.ProductProvider,
            ProductCategoryId = edit.ProductCategoryId,
            ProductManufacturerId = edit.ProductManufacturerId,
            ProductProviderId = edit.ProductProviderId
        };

        this.mainViewModel = mainViewModel;

        SelectImage = new Command(() =>
        {
            OpenFileDialog fileDialog = new()
            {
                Filter = "*.jpg|*.png"
            };

            if (fileDialog.ShowDialog() == true)
            {
                EditProduct.ProductPhoto = File.ReadAllBytes(fileDialog.FileName);

                var ms = new MemoryStream(EditProduct.ProductPhoto);

                UpdateImage(ms);
            }
        });

        RemoveImage = new Command(() =>
        {
            if (MessageBox.Show("Вы действительно хотите удалить изображение?", "Предупреждение", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            EditProduct.ProductPhoto = null;

            FileStream? fs = File.OpenRead("Images/picture.png");

            UpdateImage(fs);
        });

        BackToList = new Command(() =>
        {
            mainViewModel.CurrentPage = new ProductsListPage(mainViewModel);
        });

        Save = new Command(() =>
        {
            try
            {
                if (EditProduct.ProductPhoto is not null)
                {
                    if (EditProduct.Image.PixelHeight > 200 || EditProduct.Image.PixelWidth > 300)
                    {
                        MessageBox.Show("Невозможно сохранить продукт. Изображение слишком большое.");
                        return;
                    }
                }                

                if (EditProduct.ProductQuantityInStock < 0)
                {
                    MessageBox.Show("Невозможно сохранить продукт. Кол-во не может быть меньше 0");
                    return;
                }

                if (EditProduct.ProductCost < 0)
                {
                    MessageBox.Show("Невозможно сохранить продукт. Стоимость не может быть меньше 0");
                    return;
                }

                EditProduct.ProductPhoto ??= File.ReadAllBytes("Images\\picture.png");

                IDB.Instance.Entry(original).CurrentValues.SetValues(EditProduct);

                IDB.Instance.SaveChanges();
                BackToList.Execute(null);
            }
            catch (Exception e)
            {
                MessageBox.Show("Произошла ошибка при сохранении изменений");
            }
        });
    }

    void UpdateImage(Stream stream)
    {
        EditProduct.Image = new BitmapImage();

        EditProduct.Image.BeginInit();

        EditProduct.Image.CacheOption = BitmapCacheOption.OnLoad;
        EditProduct.Image.StreamSource = stream;

        EditProduct.Image.EndInit();
        EditProduct.Image.StreamSource.Close();

        OnPropertyChanged(nameof(EditProduct));
    }
}
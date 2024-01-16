using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNutrition.Database;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;

namespace ProjectNutrition.ViewModels
{
    public partial class ProductsViewModel : ObservableObject
    {
        public class ProductCreatedEventArgs(Product createdProduct) : EventArgs
        {
            public Product Product { get; } = createdProduct;

            public static implicit operator ProductCreatedEventArgs(Product product) => new(product);
            public static implicit operator Product(ProductCreatedEventArgs e) => e.Product;
        }
        public event EventHandler<ProductCreatedEventArgs>? OnProductCreated;



        public static string DefaultProductName => DEFAULT_PRODUCT_NAME;
        private const string DEFAULT_PRODUCT_NAME = "My Product";
        private readonly DataContext context;

        [ObservableProperty]
        private ObservableCollection<Product> products;



        public ProductsViewModel(DataContext context)
        {
            SaveNewProductCommand = new(newProductObj =>
            {
                if (!IsCreatingAProduct || newProductObj is not Product newProduct)
                    return;

                IsCreatingAProduct = false;

                if (newProduct.Name == DEFAULT_PRODUCT_NAME)
                    return;

                context.Products.Add(newProduct);
                context.Products.SaveChanges();

                Products.Add(newProduct);
                OnProductCreated?.Invoke(this, newProduct);
            });

            this.context = context;
            IsCreatingAProduct = false;
            Products = [.. this.context.Products];
        }

        #region Create
        [ObservableProperty]
        private bool isCreatingAProduct;

        [RelayCommand]
        private void StartCreatingProduct() => IsCreatingAProduct = true;

        [ObservableProperty]
        private Command saveNewProductCommand = null!;
        #endregion
    }
}

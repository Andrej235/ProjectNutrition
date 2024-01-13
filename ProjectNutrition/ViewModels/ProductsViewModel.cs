using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNutrition.Database;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;

namespace ProjectNutrition.ViewModels
{
    public partial class ProductsViewModel : ObservableObject
    {
        //Reimplement editing / deleting --- I deleted this when I implemented the productsearchview, maybe implement it in productsearchview but with a property to enable / disable it???

        public class ChangedProductEventArgs(Product createdProduct) : EventArgs
        {
            public Product Product { get; set; } = createdProduct;

            public static implicit operator ChangedProductEventArgs(Product product) => new(product);
        }
        public event EventHandler<ChangedProductEventArgs>? OnCreateNewProduct;


        public static string DefaultProductName => DEFAULT_PRODUCT_NAME;
        private const string DEFAULT_PRODUCT_NAME = "My Product";
        private readonly DataContext context;

        [ObservableProperty]
        private ObservableCollection<Product> products;



        public ProductsViewModel(DataContext context)
        {
            SaveNewProductCommand = new(newProductObj =>
            {
                if (newProductObj is not Product newProduct)
                    return;

                if (newProduct.Name == DEFAULT_PRODUCT_NAME)
                {
                    IsCreatingAProduct = false;
                    return;
                }

                context.Products.Add(newProduct);
                context.Products.SaveChanges();

                Products.Add(newProduct);
                OnCreateNewProduct?.Invoke(this, newProduct);

                IsCreatingAProduct = false;
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
        #endregion

        [ObservableProperty]
        private Command saveNewProductCommand = null!;
    }
}

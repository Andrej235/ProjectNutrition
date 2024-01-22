using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNutrition.Database;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;

namespace ProjectNutrition.ViewModels
{
    public partial class ProductsViewModel : ObservableObject
    {
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

            EditCommand = new(() => IsEditingAProduct = true);

            SelectProductCommand = new(selectedProductObj => SelectedProduct = selectedProductObj as Product);

            this.context = context;
            IsCreatingAProduct = false;
            Products = [.. this.context.Products];
        }



        #region Create
        public static string DefaultProductName => DEFAULT_PRODUCT_NAME;
        private const string DEFAULT_PRODUCT_NAME = "My Product";

        [ObservableProperty]
        private bool isCreatingAProduct;

        [RelayCommand]
        private void StartCreatingProduct() => IsCreatingAProduct = true;

        [ObservableProperty]
        private Command saveNewProductCommand = null!;

        public class ProductCreatedEventArgs(Product createdProduct) : EventArgs
        {
            public Product Product { get; } = createdProduct;

            public static implicit operator ProductCreatedEventArgs(Product product) => new(product);
            public static implicit operator Product(ProductCreatedEventArgs e) => e.Product;
        }
        public event EventHandler<ProductCreatedEventArgs>? OnProductCreated;
        #endregion

        #region Selection
        [ObservableProperty]
        private Command selectProductCommand = null!;

        [ObservableProperty]
        private Product? selectedProduct;

        public void BackButtonPressed()
        {
            if (SelectedProduct is null)
                return;

            if (IsEditingAProduct)
                CloseEditProductDialog();
            else
                SelectedProduct = null;
        }

        #region Editing
        [ObservableProperty]
        private bool isEditingAProduct;

        [ObservableProperty]
        private Product? productToEdit;

        [ObservableProperty]
        private Command editCommand;

        public void CloseEditProductDialog()
        {
            IsEditingAProduct = false;
            ProductToEdit = null;

            context.SaveChanges();
        }
        #endregion

        #endregion
    }
}

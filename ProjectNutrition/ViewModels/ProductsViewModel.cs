using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LocalJSONDatabase.Core;
using ProjectNutrition.Database;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;

namespace ProjectNutrition.ViewModels
{
    public partial class ProductsViewModel : ObservableObject
    {
        private const string NEW_PRODUCT_DEFAULT_NAME = "My Product";

        [ObservableProperty]
        private ObservableCollection<Product> products;

        private static DBTable<Product> DBProducts => DataContext.Context.Products;

        public ProductsViewModel()
        {
            Products = [.. DataContext.Context.Products];

            IsCreatingAProduct = false;
            NewProduct = new();
        }

        #region Delete
        [ObservableProperty]
        private bool isDeletingAProduct;
        private Product? productToDelete;

        [RelayCommand]
        void OpenDeletionDialog(object productToDelete)
        {
            if (productToDelete is not Product product)
                return;

            this.productToDelete = product;
            IsDeletingAProduct = true;
        }

        [RelayCommand]
        void CancelDeletionDialog()
        {
            IsDeletingAProduct = false;
            productToDelete = null;
        }

        [RelayCommand]
        void ConfirmDeleteDialog()
        {
            if (productToDelete is null)
                return;

            Products.Remove(productToDelete);
            DBProducts.Delete(productToDelete);
            DBProducts.SaveChanges();

            IsDeletingAProduct = false;
            productToDelete = null;
        }
        #endregion

        #region Create
        [ObservableProperty]
        private Product newProduct;

        [ObservableProperty]
        private bool isCreatingAProduct;

        private void Add()
        {
            if (NewProduct.Name == NEW_PRODUCT_DEFAULT_NAME)
            {
                IsCreatingAProduct = false;
                return;
            }

            NewProduct.Id = (Products.MaxBy(x => x.Id)?.Id ?? 0) + 1;
            Products.Add(NewProduct);
            DBProducts.Add(NewProduct);
            DBProducts.SaveChanges();

            IsCreatingAProduct = false;
        }

        [RelayCommand]
        private void StartCreatingProduct()
        {
            NewProduct = new() { Name = NEW_PRODUCT_DEFAULT_NAME };
            IsCreatingAProduct = true;
        }
        #endregion

        #region Edit
        private bool isEditingProduct;

        [RelayCommand]
        void StartEditingProduct(Product productToEdit)
        {
            NewProduct = productToEdit;

            isEditingProduct = true;
            IsCreatingAProduct = true;
        }
        #endregion

        [RelayCommand]
        void Back()
        {
            if (IsCreatingAProduct)
            {
                if (!isEditingProduct)
                    Add();
                else
                {
                    IsCreatingAProduct = false;
                    isEditingProduct = false;
                    DBProducts.SaveChanges();
                }
            }
            else if (IsDeletingAProduct)
            {
                CancelDeletionDialog();
                productToDelete = null;
            }
        }
    }
}

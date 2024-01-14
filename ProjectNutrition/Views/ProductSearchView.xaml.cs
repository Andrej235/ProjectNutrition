using ProjectNutrition.Models;
using ProjectNutrition.ViewModels;
namespace ProjectNutrition.Views;

public partial class ProductSearchView : ContentView
{
    public ProductSearchView()
    {
        InitializeComponent();
        BindingContext = MauiProgram.GetService<ProductSearchViewModel>();
    }

    public void AddNewProduct(Product productToAdd)
    {
        if (BindingContext is ProductSearchViewModel vm)
            vm.Products.Add(productToAdd);
    }

    public void CloseEditingDialog()
    {
        if (BindingContext is ProductSearchViewModel vm)
            vm.CloseEditProductDialog();
    }
}
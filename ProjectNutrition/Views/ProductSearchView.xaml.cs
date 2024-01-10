using ProjectNutrition.ViewModels;
namespace ProjectNutrition.Views;

public partial class ProductSearchView : ContentView
{
    public ProductSearchView()
    {
        InitializeComponent();
        BindingContext = MauiProgram.GetService<ProductSearchViewModel>();
    }
}
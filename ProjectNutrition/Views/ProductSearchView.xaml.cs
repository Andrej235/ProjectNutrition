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

    public void Add(Product productToAdd)
    {
        if (BindingContext is ProductSearchViewModel vm)
            vm.Products.Add(productToAdd);
    }

    public void CloseEditingDialog()
    {
        if (BindingContext is ProductSearchViewModel vm)
            vm.CloseEditProductDialog();
    }

    public static readonly BindableProperty IsEditingEnabledProperty = BindableProperty.Create(
        nameof(IsEditingEnabled),
        typeof(bool),
        typeof(ProductSearchView),
        false,
        propertyChanged: (bindable, old, @new) =>
        {
            var @this = (ProductSearchView)bindable;

            if (@new is not bool isEditingEnabled)
                return;

            @this.IsEditingEnabled = isEditingEnabled;
        });

    public bool IsEditingEnabled
    {
        get => (bool)GetValue(IsEditingEnabledProperty);
        set
        {
            SetValue(IsEditingEnabledProperty, value);

            if (BindingContext is ProductSearchViewModel vm)
                vm.IsEditingEnabled = value;
        }
    }
}
using ProjectNutrition.ViewModels;

namespace ProjectNutrition.Pages;

public partial class MealsPage : ContentPage
{
    public MealsPage(MealsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        (productSearchView.BindingContext as ProductSearchViewModel ?? throw new NullReferenceException()).OnProductSelected += vm.OnProductSelectedAsIngredient;
    }

    protected override bool OnBackButtonPressed()
    {
        if (BindingContext is not MealsViewModel vm)
            return false;

        vm.BackCommand.Execute(null);
        return true;
    }
}
using ProjectNutrition.ViewModels;

namespace ProjectNutrition.Pages;

public partial class MealsPage : ContentPage
{
    public MealsPage(MealsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        vm.OnMealCreated += OnMealCreated;
    }

    private void OnMealCreated(object? sender, MealsViewModel.MealCreatedEventArgs e) => mealsDisplay.Add(e);

    protected override bool OnBackButtonPressed()
    {
        creationDialogView.Save();

        return true;
    }
}
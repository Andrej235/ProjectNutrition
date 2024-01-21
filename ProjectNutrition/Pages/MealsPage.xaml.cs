using ProjectNutrition.ViewModels;

namespace ProjectNutrition.Pages;

public partial class MealsPage : ContentPage
{
    public MealsPage(MealsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;

        vm.OnMealCreated += OnMealCreated;
        mealsDisplay.OnMealDragStateChanged += OnMealDragStateChangedSearchView;
    }

    private void OnMealDragStateChangedSearchView(object? sender, MealSearchViewModel.OnMealDragStateChangedEventArgs e)
    {
        switch (e.NewState)
        {
            case MealSearchViewModel.DragState.Started:
                createBtn.FadeTo(0, 100);
                break;
            case MealSearchViewModel.DragState.Ended:
                createBtn.FadeTo(1, 100);
                break;
            default:
                break;
        }
    }

    private void OnMealCreated(object? sender, MealsViewModel.MealCreatedEventArgs e) => mealsDisplay.Add(e);

    protected override bool OnBackButtonPressed()
    {
        creationDialogView.Save();

        if (BindingContext is not MealsViewModel vm)
            return true;

        vm.BackButtonPressed();
        return true;
    }
}
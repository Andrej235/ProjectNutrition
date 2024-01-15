using ProjectNutrition.ViewModels;

namespace ProjectNutrition.Pages;

public partial class MealsPage : ContentPage
{
    public MealsPage(MealsViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override bool OnBackButtonPressed()
    {
        creationDialogView.Save();

        return true;
    }
}
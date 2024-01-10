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
        if (BindingContext is not MealsViewModel vm)
            return false;

        vm.BackCommand.Execute(null);
        return true;
    }
}
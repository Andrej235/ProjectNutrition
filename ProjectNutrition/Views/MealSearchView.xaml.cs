using ProjectNutrition.Models;
using ProjectNutrition.ViewModels;

namespace ProjectNutrition.Views
{
    public partial class MealSearchView : ContentView
    {
        public MealSearchView()
        {
            InitializeComponent();
            BindingContext = MauiProgram.GetService<MealSearchViewModel>();
        }

        public void Add(Meal mealToAdd)
        {
            if (BindingContext is MealSearchViewModel vm)
                vm.Meals.Add(mealToAdd);
        }
    }
}
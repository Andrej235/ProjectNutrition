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
    }
}
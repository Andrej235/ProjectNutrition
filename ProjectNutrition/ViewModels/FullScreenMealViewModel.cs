using CommunityToolkit.Mvvm.ComponentModel;
using ProjectNutrition.Models;

namespace ProjectNutrition.ViewModels
{
    public partial class FullScreenMealViewModel : ObservableObject
    {
        public Meal? Meal
        {
            get => meal;
            set
            {
                SetProperty(ref meal, value);

                Calories = value?.GetCalories();
                Proteins = value?.GetProtein();
                Carbs = value?.GetCarbs();
                Fats = value?.GetFats();
                Fibers = value?.GetFibers();
            }
        }
        private Meal? meal;



        [ObservableProperty]
        private Command editCommand = null!;

        [ObservableProperty]
        private float? calories;

        [ObservableProperty]
        private float? proteins;

        [ObservableProperty]
        private float? carbs;

        [ObservableProperty]
        private float? fats;

        [ObservableProperty]
        private float? fibers;
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using ProjectNutrition.Models;

namespace ProjectNutrition.ViewModels
{
    public partial class FullScreenMealViewModel : ObservableObject
    {
        [ObservableProperty]
        private Meal? meal;

        [ObservableProperty]
        private Command editCommand = null!;
    }
}

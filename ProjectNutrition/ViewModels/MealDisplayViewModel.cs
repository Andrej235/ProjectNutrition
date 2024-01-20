using CommunityToolkit.Mvvm.ComponentModel;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;

namespace ProjectNutrition.ViewModels
{
    public partial class MealDisplayViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Meal> meals = [];
    }
}

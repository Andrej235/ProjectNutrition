using CommunityToolkit.Mvvm.ComponentModel;
using ProjectNutrition.Database;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;

namespace ProjectNutrition.ViewModels
{
    public partial class MealSearchViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Meal> meals = null!;

        private readonly DataContext context;
        public MealSearchViewModel(DataContext context)
        {
            this.context = context;
            Meals = [.. context.Meals];
        }
    }
}

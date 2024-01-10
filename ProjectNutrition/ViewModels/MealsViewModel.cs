using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNutrition.Database;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ProjectNutrition.ViewModels
{
    public partial class MealsViewModel : ObservableObject
    {
        private const string NEW_MEAL_DEFAULT_NAME = "My Meal";
        private readonly DataContext context;

        [ObservableProperty]
        private ObservableCollection<Meal> meals;

        public MealsViewModel(DataContext context)
        {
            this.context = context;
            NewMeal = new() { Name = NEW_MEAL_DEFAULT_NAME };

            meals = [.. this.context.Meals];
        }

        [RelayCommand]
        private void Back()
        {
            if (IsCreatingAMeal)
            {
                IsCreatingAMeal = false;
            }
        }

        public void OnProductSelected(object? sender, ProductSearchViewModel.ProductSelectedEventArgs e)
        {
            Debug.WriteLine($"---> It works! {e.Product.Name}");
        }

        #region Create
        [ObservableProperty]
        private Meal newMeal;

        [ObservableProperty]
        private bool isCreatingAMeal;

        [RelayCommand]
        private void StartCreatingMeal()
        {
            IsCreatingAMeal = true;
            NewMeal = new() { Name = NEW_MEAL_DEFAULT_NAME };

        }
        #endregion
    }
}

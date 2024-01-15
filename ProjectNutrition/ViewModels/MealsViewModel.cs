using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNutrition.Database;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;

namespace ProjectNutrition.ViewModels
{
    public partial class MealsViewModel : ObservableObject
    {
        public static string NewMealDefaultName => NEW_MEAL_DEFAULT_NAME;
        private const string NEW_MEAL_DEFAULT_NAME = "My Meal";

        private readonly DataContext context;

        [ObservableProperty]
        private ObservableCollection<Meal> meals;

        public MealsViewModel(DataContext context)
        {
            SaveNewProductCommand = new(newMealObj =>
            {
                if (!IsCreatingAMeal || newMealObj is not Meal newMeal)
                    return;

                IsCreatingAMeal = false;

                if (newMeal.Name == NEW_MEAL_DEFAULT_NAME || !newMeal.Products.Any())
                    return;

                context.Meals.Add(newMeal);
                foreach (var x in newMeal.Products)
                    context.MealProducts.Add(x);

                context.SaveChanges();
                Meals.Add(newMeal);
            });

            this.context = context;

            meals = [.. this.context.Meals];
        }

        #region Create
        [ObservableProperty]
        private bool isCreatingAMeal;

        [RelayCommand]
        private void StartCreatingMeal() => IsCreatingAMeal = true;

        [ObservableProperty]
        private Command saveNewProductCommand = null!;
        #endregion
    }
}

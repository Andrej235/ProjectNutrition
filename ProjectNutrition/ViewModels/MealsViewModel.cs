using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNutrition.Database;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;

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
            newMealProducts = [];
        }

        [RelayCommand]
        private void Back()
        {
            if (IsChoosingIngredient)
            {
                IsChoosingIngredient = false;
            }
            else if (IsCreatingAMeal)
            {
                IsCreatingAMeal = false;
                if (NewMeal.Name == NEW_MEAL_DEFAULT_NAME)
                    return;

                NewMeal.Products = NewMealProducts.Where(x => x.Amount > 0);

                if (!NewMeal.Products.Any())
                    return;

                context.Meals.Add(NewMeal);
                foreach (var x in NewMealProducts)
                    context.MealProducts.Add(x);

                context.SaveChanges();

                Meals.Add(NewMeal);
            }
        }

        #region Create
        [ObservableProperty]
        private Meal newMeal;

        [ObservableProperty]
        private ObservableCollection<MealProduct> newMealProducts;

        [ObservableProperty]
        private bool isCreatingAMeal;

        [ObservableProperty]
        private bool isChoosingIngredient;

        [RelayCommand]
        private void StartCreatingMeal()
        {
            IsCreatingAMeal = true;
            NewMealProducts = [];
            NewMeal = new() { Name = NEW_MEAL_DEFAULT_NAME };
        }

        public void OnProductSelectedAsIngredient(object? sender, ProductSearchViewModel.ProductSelectedEventArgs e)
        {
            IsChoosingIngredient = false;
            NewMealProducts.Add(new(NewMeal, e.Product));
        }

        [RelayCommand]
        private void OnBeginSelectingIngredient()
        {
            IsChoosingIngredient = true;
        }
        #endregion
    }
}

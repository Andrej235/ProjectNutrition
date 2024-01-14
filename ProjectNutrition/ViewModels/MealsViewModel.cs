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

            meals = [.. this.context.Meals];
        }

        [RelayCommand]
        private void Back()
        {
            if (IsCreatingAMeal)
                IsCreatingAMeal = false;

            //TODO: if IsCreatingAMeal should also somehow tell NewMealCreationView to save the new meal, also add bindable properties for default name and save command

            /*            if (IsChoosingIngredient)
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
                        }*/
        }

        #region Create
        [ObservableProperty]
        private bool isCreatingAMeal;

        [RelayCommand]
        private void StartCreatingMeal() => IsCreatingAMeal = true;
        #endregion
    }
}

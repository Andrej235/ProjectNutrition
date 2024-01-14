using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;

namespace ProjectNutrition.ViewModels
{
    public partial class NewMealCreationDialogViewModel : ObservableObject
    {
        public NewMealCreationDialogViewModel()
        {
            NewMeal = new();
            NewMealProducts = [];
        }

        [ObservableProperty]
        private Meal newMeal;

        [ObservableProperty]
        private ObservableCollection<MealProduct> newMealProducts;

        [ObservableProperty]
        private bool isChoosingIngredient;

        [RelayCommand]
        private void BeginSelectingIngredient()
        {
            IsChoosingIngredient = true;
        }

        public void OnProductSelectedAsIngredient(object? sender, ProductSearchViewModel.ProductSelectedEventArgs e)
        {
            NewMealProducts.Add(new(NewMeal, e.Product));
            IsChoosingIngredient = false;
        }
    }
}

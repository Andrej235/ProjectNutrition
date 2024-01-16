using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNutrition.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ProjectNutrition.ViewModels
{
    public partial class NewMealCreationDialogViewModel : ObservableObject
    {
        public NewMealCreationDialogViewModel()
        {
            NewMealProducts = [];
            defaultMealName = "Meal";
            NewMeal = new() { Name = defaultMealName };
        }

        [ObservableProperty]
        private Meal newMeal;

        [ObservableProperty]
        private ObservableCollection<MealProduct> newMealProducts;

        [ObservableProperty]
        private bool isChoosingIngredient;

        [ObservableProperty]
        private Command? saveCommand;

        public string DefaultMealName
        {
            get => defaultMealName;
            set
            {
                if (NewMeal.Name == defaultMealName)
                    NewMeal.Name = value;

                SetProperty(ref defaultMealName, value);
            }
        }
        private string defaultMealName;



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

        public void Save()
        {
            NewMeal.Products = NewMealProducts 
                .Where(x => x.Amount > 0)
                .GroupBy(x => x.Product.Id)
                .Select(x =>
                {
                    if (x.Count() == 1)
                        return x.ElementAt(0);
                    
                    var first = x.ElementAt(0);
                    return new(first.Id, first.Meal, first.Product, x.Sum(x => x.Amount));
                });
            SaveCommand?.Execute(NewMeal);
        }
    }
}

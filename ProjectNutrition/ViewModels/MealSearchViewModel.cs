using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
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

        #region Deletion
        [ObservableProperty]
        private bool isDragingMeal;
        private Meal? mealToDelete;

        [RelayCommand]
        private void StartMealDrag(Element element)
        {
            if (element is not DragGestureRecognizer dragGR || dragGR.Parent is not Grid grid || grid.BindingContext is not Meal mealToDelete)
                return;

            grid.Background = Color.FromRgba(200, 0, 0, 0.5);
            this.mealToDelete = mealToDelete;
            IsDragingMeal = true;
        }

        [RelayCommand]
        private void ConfirmMealDeletion()
        {
            if (mealToDelete is null)
                return;

            Meals.Remove(mealToDelete);

            context.Meals.Delete(mealToDelete);
            context.SaveChanges();

            mealToDelete = null;
        }

        [RelayCommand]
        private void DropMeal(Element element)
        {
            if (element is not DragGestureRecognizer dragGR || dragGR.Parent is not Grid grid || grid.BindingContext is not Meal)
                return;

            grid.Background = Color.FromRgba(200, 0, 0, 0);
            mealToDelete = null;
            IsDragingMeal = false;
        }
        #endregion
    }
}

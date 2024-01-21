using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectNutrition.Database;
using ProjectNutrition.Models;

namespace ProjectNutrition.ViewModels
{
    public partial class MealsViewModel : ObservableObject
    {
        public class MealCreatedEventArgs(Meal meal) : EventArgs
        {
            public Meal Meal { get; } = meal;

            public static implicit operator MealCreatedEventArgs(Meal meal) => new(meal);
            public static implicit operator Meal(MealCreatedEventArgs e) => e.Meal;
        }
        public event EventHandler<MealCreatedEventArgs>? OnMealCreated;



        public static string NewMealDefaultName => NEW_MEAL_DEFAULT_NAME;
        private const string NEW_MEAL_DEFAULT_NAME = "My Meal";
        private readonly DataContext context;

        public MealsViewModel(DataContext context)
        {
            this.context = context;

            SaveNewMealCommand = new(newMealObj =>
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
                OnMealCreated?.Invoke(this, newMeal);
            });

            SelectMealCommand = new Command(selectedMealObj => SelectedMeal = selectedMealObj as Meal);
        }

        #region Create
        [ObservableProperty]
        private bool isCreatingAMeal;

        [RelayCommand]
        private void StartCreatingMeal() => IsCreatingAMeal = true;

        [ObservableProperty]
        private Command saveNewMealCommand = null!;
        #endregion

        #region Selection
        [ObservableProperty]
        private Meal? selectedMeal;

        [ObservableProperty]
        private Command selectMealCommand;

        public void BackButtonPressed()
        {
            if (SelectedMeal is null)
                return;

            if (IsEditingAMeal)
                CloseEditMealDialog();
            else
                SelectedMeal = null;
        }

        #region Editing
        [ObservableProperty]
        private bool isEditingAMeal;

        [ObservableProperty]
        private Meal? mealToEdit;

        [ObservableProperty]
        private Command editCommand; //TODO: Implement editing

        public void CloseEditMealDialog()
        {
            IsEditingAMeal = false;
            MealToEdit = null;

            context.SaveChanges();
        }
        #endregion

        #endregion
    }
}

using Microsoft.Maui.Animations;
using ProjectNutrition.Models;
using ProjectNutrition.ViewModels;
using static ProjectNutrition.ViewModels.MealSearchViewModel;
using Animation = Microsoft.Maui.Controls.Animation;

namespace ProjectNutrition.Views
{
    public partial class MealSearchView : ContentView
    {
        public event EventHandler<OnMealDragStateChangedEventArgs>? OnMealDragStateChanged;

        public MealSearchView()
        {
            InitializeComponent();
            var vm = MauiProgram.GetService<MealSearchViewModel>() ?? throw new NullReferenceException();

            BindingContext = vm;
            vm.OnMealDragStateChanged += OnMealDragStateChangedVM;
        }

        private void OnMealDragStateChangedVM(object? sender, OnMealDragStateChangedEventArgs e)
        {
            Animation gridAnim = [];

            switch (e.NewState)
            {
                case DragState.Started:
                    gridAnim.Add(0, 1, new Animation(value => e.ElementToAnimate.BackgroundColor = Color.FromRgba(200, 0, 0, 0).Lerp(Color.FromRgba(200, 0, 0, 0.5), value)));
                    deleteIcon.FadeTo(1, 100);
                    break;
                case DragState.Ended:
                    gridAnim.Add(0, 1, new Animation(value => e.ElementToAnimate.BackgroundColor = Color.FromRgba(200, 0, 0, 0.5).Lerp(Color.FromRgba(200, 0, 0, 0), value)));
                    deleteIcon.FadeTo(0, 100);
                    break;
                default:
                    break;
            }
            gridAnim.Commit(this, "MealItemBGChange", 16, 125);

            OnMealDragStateChanged?.Invoke(sender, e);
        }

        public void Add(Meal mealToAdd)
        {
            if (BindingContext is MealSearchViewModel vm)
                vm.Meals.Add(mealToAdd);
        }
    }
}
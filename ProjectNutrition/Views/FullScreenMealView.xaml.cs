using ProjectNutrition.Models;
using ProjectNutrition.ViewModels;

namespace ProjectNutrition.Views
{
    public partial class FullScreenMealView : ContentView
    {
    	public FullScreenMealView()
    	{
    		InitializeComponent();
            VM = MauiProgram.GetService<FullScreenMealViewModel>() ?? throw new NullReferenceException();
            wrapper.BindingContext = VM;
        }

        public FullScreenMealViewModel VM { get; }


        public Meal? Meal
        {
            get => (Meal)GetValue(MealProperty);
            set
            {
                SetValue(MealProperty, value);
                VM.Meal = value;
                //mealsDisplay.Meals = [.. value?.UsedInMeals.Select(x => x.Meal)];
            }
        }
        public static readonly BindableProperty MealProperty = BindableProperty.Create(
            nameof(Meal),
            typeof(Meal),
            typeof(FullScreenMealViewModel),
            null,
            BindingMode.TwoWay,
            propertyChanging: (bindable, old, @new) =>
            {
                var @this = (FullScreenMealView)bindable;

                if (@new is not Meal meal)
                    return;

                @this.Meal = meal;
            });

        public Command EditCommand
        {
            get => (Command)GetValue(EditCommandProperty);
            set
            {
                SetValue(EditCommandProperty, value);
                VM.EditCommand = value;
            }
        }
        public static readonly BindableProperty EditCommandProperty = BindableProperty.Create(
            nameof(EditCommand),
            typeof(Command),
            typeof(FullScreenMealViewModel),
            new Command(() => throw new NotImplementedException()),
            BindingMode.TwoWay,
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (FullScreenMealView)bindable;

                if (@new is not Command command)
                    return;

                @this.EditCommand = command;
            });
    }
}
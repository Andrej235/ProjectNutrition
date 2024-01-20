using ProjectNutrition.Models;
using ProjectNutrition.ViewModels;

namespace ProjectNutrition.Views
{
    public partial class MealsDisplayView : ContentView
    {
        private MealDisplayViewModel vm;
        public MealsDisplayView()
        {
            InitializeComponent();

            vm = MauiProgram.GetService<MealDisplayViewModel>() ?? throw new NullReferenceException();
            wrapper.BindingContext = vm;
        }

        public IEnumerable<Meal> Meals
        {
            get => (IEnumerable<Meal>)GetValue(MealsProperty);
            set
            {
                SetValue(MealsProperty, value);
                vm.Meals = [.. value];
            }
        }
        public static readonly BindableProperty MealsProperty = BindableProperty.Create(
            nameof(Meals),
            typeof(IEnumerable<Meal>),
            typeof(MealsDisplayView),
            new List<Meal>(),
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (MealsDisplayView)bindable;
                if (@new is not IEnumerable<Meal> meals)
                    return;

                @this.Meals = meals;
            });
    }
}
using ProjectNutrition.Models;
using ProjectNutrition.ViewModels;

namespace ProjectNutrition.Views
{
    public partial class FullScreenProductView : ContentView
    {
        public FullScreenProductView()
        {
            InitializeComponent();
            VM = MauiProgram.GetService<FullScreenProductViewModel>() ?? throw new NullReferenceException();
            wrapper.BindingContext = VM;
        }

        public FullScreenProductViewModel VM { get; }

        public Product? Product
        {
            get => (Product)GetValue(ProductProperty);
            set
            {
                SetValue(ProductProperty, value);
                VM.Product = value;
                mealsDisplay.Meals = [.. value?.UsedInMeals.Select(x => x.Meal)];
            }
        }
        public static readonly BindableProperty ProductProperty = BindableProperty.Create(
            nameof(Product),
            typeof(Product),
            typeof(FullScreenProductViewModel),
            null,
            BindingMode.TwoWay,
            propertyChanging: (bindable, old, @new) =>
            {
                var @this = (FullScreenProductView)bindable;

                if (@new is not Product product)
                    return;

                @this.Product = product;
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
            typeof(FullScreenProductViewModel),
            new Command(() => throw new NotImplementedException()),
            BindingMode.TwoWay,
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (FullScreenProductView)bindable;

                if (@new is not Command command)
                    return;

                @this.EditCommand = command;
            });
    }
}
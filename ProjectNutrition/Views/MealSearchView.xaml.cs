using Microsoft.Maui.Animations;
using ProjectNutrition.Models;
using ProjectNutrition.ViewModels;
using static ProjectNutrition.ViewModels.MealSearchViewModel;
using Animation = Microsoft.Maui.Controls.Animation;

namespace ProjectNutrition.Views
{
    public partial class MealSearchView : ContentView
    {
        private readonly MealSearchViewModel vm;

        public event EventHandler<OnMealDragStateChangedEventArgs>? OnMealDragStateChanged;

        public MealSearchView()
        {
            InitializeComponent();
            vm = MauiProgram.GetService<MealSearchViewModel>() ?? throw new NullReferenceException();

            wrapper.BindingContext = vm;
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
            if (wrapper.BindingContext is MealSearchViewModel vm)
                vm.Meals.Add(mealToAdd);
        }

        public bool IsEditingEnabled
        {
            get => (bool)GetValue(IsEditingEnabledProperty);
            set
            {
                SetValue(IsEditingEnabledProperty, value);
                vm.IsEditingEnabled = value;
            }
        }
        public static readonly BindableProperty IsEditingEnabledProperty = BindableProperty.Create(
            nameof(IsEditingEnabled),
            typeof(bool),
            typeof(MealSearchView),
            false,
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (MealSearchView)bindable;

                if (@new is not bool isEditingEnabled)
                    return;

                @this.IsEditingEnabled = isEditingEnabled;
            });

        public Command SelectCommand
        {
            get => (Command)GetValue(SelectCommandProperty);
            set
            {
                SetValue(SelectCommandProperty, value);
                vm.SelectCommand = value;
            }
        }
        public static readonly BindableProperty SelectCommandProperty = BindableProperty.Create(
            nameof(SelectCommand),
            typeof(Command),
            typeof(MealSearchView),
            new Command(() => throw new NotImplementedException()),
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (MealSearchView)bindable;
                if (@new is Command command)
                    @this.SelectCommand = command;
            });
    }
}
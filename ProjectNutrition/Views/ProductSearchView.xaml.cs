using Microsoft.Maui.Animations;
using ProjectNutrition.Models;
using ProjectNutrition.ViewModels;
using static ProjectNutrition.ViewModels.ProductSearchViewModel;
using Animation = Microsoft.Maui.Controls.Animation;

namespace ProjectNutrition.Views
{
    public partial class ProductSearchView : ContentView
    {
        public event EventHandler<OnProductDragStateChangedEventArgs>? OnProductDragStateChanged;

        private readonly ProductSearchViewModel vm;
        public ProductSearchView()
        {
            InitializeComponent();
            vm = MauiProgram.GetService<ProductSearchViewModel>() ?? throw new NullReferenceException();

            wrapper.BindingContext = vm;
            vm.OnProductDragStateChanged += OnProductDragStateChangedVM;
        }

        private void OnProductDragStateChangedVM(object? sender, OnProductDragStateChangedEventArgs e)
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
            gridAnim.Commit(this, "ProcuctItemBGChange", 16, 125);

            OnProductDragStateChanged?.Invoke(sender, e);
        }

        public void Add(Product productToAdd) => vm.Products.Add(productToAdd);

        public void CloseEditingDialog() => vm.CloseEditProductDialog();

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
            typeof(ProductSearchView),
            false,
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (ProductSearchView)bindable;

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
            typeof(ProductSearchView),
            new Command(() => throw new NotImplementedException()),
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (ProductSearchView)bindable;
                if (@new is Command command)
                    @this.SelectCommand = command;
            });
    }
}
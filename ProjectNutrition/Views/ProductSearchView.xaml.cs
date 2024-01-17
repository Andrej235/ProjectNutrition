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
        public ProductSearchView()
        {
            InitializeComponent();
            var vm = MauiProgram.GetService<ProductSearchViewModel>() ?? throw new NullReferenceException();

            BindingContext = vm;
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

        public void Add(Product productToAdd)
        {
            if (BindingContext is ProductSearchViewModel vm)
                vm.Products.Add(productToAdd);
        }

        public void CloseEditingDialog()
        {
            if (BindingContext is ProductSearchViewModel vm)
                vm.CloseEditProductDialog();
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

        public bool IsEditingEnabled
        {
            get => (bool)GetValue(IsEditingEnabledProperty);
            set
            {
                SetValue(IsEditingEnabledProperty, value);

                if (BindingContext is ProductSearchViewModel vm)
                    vm.IsEditingEnabled = value;
            }
        }
    }
}
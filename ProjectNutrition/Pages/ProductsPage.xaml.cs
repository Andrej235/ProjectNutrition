using CommunityToolkit.Maui.Converters;
using ProjectNutrition.ViewModels;
using static ProjectNutrition.ViewModels.ProductsViewModel;

namespace ProjectNutrition.Pages
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage(ProductsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

            vm.OnProductCreated += OnProductCreated;
            productsDisplay.OnProductDragStateChanged += OnProductDragStateChangedSeachView;
        }

        private void OnProductDragStateChangedSeachView(object? sender, ProductSearchViewModel.OnProductDragStateChangedEventArgs e)
        {
            switch (e.NewState)
            {
                case ProductSearchViewModel.DragState.Started:
                    createBtn.FadeTo(0, 100);
                    break;
                case ProductSearchViewModel.DragState.Ended:
                    createBtn.FadeTo(1, 100);
                    break;
                default:
                    break;
            }
        }

        private void OnProductCreated(object? sender, ProductCreatedEventArgs e) => productsDisplay.Add(e);

        protected override bool OnBackButtonPressed()
        {
            if (BindingContext is ProductsViewModel vm)
                vm.BackButtonPressed();

            createProductDialog.Save();

            productsDisplay.CloseEditingDialog();

            return true;
        }
    }
}
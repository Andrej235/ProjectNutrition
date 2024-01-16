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
        }

        private void OnProductCreated(object? sender, ProductCreatedEventArgs e) => productsDisplay.Add(e);

        protected override bool OnBackButtonPressed()
        {
            createProductDialog.Save();

            productsDisplay.CloseEditingDialog();

            return true;
        }
    }
}
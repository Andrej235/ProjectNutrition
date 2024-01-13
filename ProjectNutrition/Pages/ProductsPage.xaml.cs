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

            vm.OnCreateNewProduct += OnCreateNewProduct;
        }

        private void OnCreateNewProduct(object? sender, ChangedProductEventArgs e) => productsDisplay.AddNewProduct(e.Product);

        protected override bool OnBackButtonPressed()
        {
            createProductDialog.Save();

            return true;
        }
    }
}
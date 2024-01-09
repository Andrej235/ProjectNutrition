using ProjectNutrition.ViewModels;

namespace ProjectNutrition.Pages
{
    public partial class ProductsPage : ContentPage
    {
        public ProductsPage(ProductsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        protected override bool OnBackButtonPressed()
        {
            if (BindingContext is not ProductsViewModel vm)
                return false;

            vm.BackCommand.Execute(null);
            return true;
        }
    }
}
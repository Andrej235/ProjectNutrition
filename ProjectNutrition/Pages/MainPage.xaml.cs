using ProjectNutrition.Models;

namespace ProjectNutrition.Pages
{
    public partial class MainPage : ContentPage
    {
        private const string NEW_PRODUCT_DEFAULT_NAME = "My Product";

        private List<Product>? products;
        public List<Product> Products
        {
            get => products ?? [];
            set
            {
                products = value ?? [];
                OnPropertyChanged();
            }
        }


        public MainPage()
        {
            InitializeComponent();

            Products = [
                new()
                {
                    Calories = 150,
                    Carbs = 10,
                    Fats = 10,
                    Fibers = 10,
                    Proteins = 10,
                    Id = 1,
                    Name = "An ingedient"
                },
                new()
                {
                    Calories = 500,
                    Carbs = 20,
                    Fats = 25,
                    Fibers = 15,
                    Proteins = 5,
                    Id = 1,
                    Name = "A different ingedient"
                }];

            RefreshProductCollection();
        }

        private void RefreshProductCollection()
        {
            ProductCollection.ItemsSource = null;
            ProductCollection.ItemsSource = Products;
        }

        private void OnAddNewProductBtnClicked(object sender, EventArgs e)
        {
            Products.Add(new()
            {
                Name = NEW_PRODUCT_DEFAULT_NAME
            });

            addNewProductWrapper.BindingContext = null;
            addNewProductWrapper.BindingContext = Products.Last();
            addNewProductWrapper.IsVisible = true;
        }

        protected override bool OnBackButtonPressed()
        {
            if (addNewProductWrapper.IsVisible)
            {
                addNewProductWrapper.IsVisible = false;
                var addedProduct = Products.Last();
                if (addedProduct.Name == NEW_PRODUCT_DEFAULT_NAME)
                    Products.Remove(addedProduct);

                RefreshProductCollection();
                return true;
            }
            else if (ProductDeletionConfirmDialogWrapper.IsVisible)
            {
                CancelProductDeletion.Execute(null);
                return true;
            }

            return false;
        }
        private async static void GoBack() => await Shell.Current.GoToAsync("..");

        private void OnProductselect(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OnDeleteProductClicked(object sender, EventArgs e)
        {
            if (sender is not ImageButton imageButton || imageButton.BindingContext is not Product Product)
                return;

            ProductDeletionConfirmDialogWrapper.BindingContext = null;
            ProductDeletionConfirmDialogWrapper.BindingContext = Product;
            ProductDeletionConfirmDialogWrapper.IsVisible = true;
        }

        private void OnEditProductClicked(object sender, EventArgs e)
        {
            if (sender is not ImageButton imageButton || imageButton.BindingContext is not Product Product)
                return;

            addNewProductWrapper.BindingContext = null;
            addNewProductWrapper.BindingContext = Product;
            addNewProductWrapper.IsVisible = true;
        }

        public Command CancelProductDeletion => new(() => ProductDeletionConfirmDialogWrapper.IsVisible = false);

        private void OnProductDeletionConfirmed(object sender, EventArgs e)
        {
            if (sender is not Button button || button.BindingContext is not Product Product)
                return;

            Products.Remove(Product);
            RefreshProductCollection();
            ProductDeletionConfirmDialogWrapper.IsVisible = false;
        }
    }
}
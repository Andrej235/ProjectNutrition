using ProjectNutrition.Models;

namespace ProjectNutrition.Views
{
    public partial class ProductEditingDialogView : ContentView
    {
        public ProductEditingDialogView()
        {
            InitializeComponent();
        }

        public Product Product
        {
            get => (Product)GetValue(ProductProperty);
            set => SetValue(ProductProperty, value);
        }
        public static readonly BindableProperty ProductProperty = BindableProperty.Create(
            nameof(Product),
            typeof(Models.Product),
            typeof(ProductEditingDialogView),
            new Product(),
            BindingMode.TwoWay,
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (ProductEditingDialogView)bindable;
                if (@new is not Product product)
                    return;

                @this.Product = product;

                @this.productInputWrapper.BindingContext = @this.Product;
            });
    }
}
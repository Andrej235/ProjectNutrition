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

        public Product? Product
        {
            get => (Product)GetValue(ProductProperty);
            set
            {
                SetValue(ProductProperty, value);
                VM.Product = value;
            }
        }

        public FullScreenProductViewModel VM { get; }

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
    }
}
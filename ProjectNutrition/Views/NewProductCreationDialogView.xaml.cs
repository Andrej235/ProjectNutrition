using ProjectNutrition.Models;

namespace ProjectNutrition.Views
{
    public partial class NewProductCreationDialogView : ContentView
    {
        public Product NewProduct
        {
            get => newProduct;
            set => newProduct = value;
        }
        private Product newProduct;

        public NewProductCreationDialogView()
        {
            InitializeComponent();

            newProduct = new() { Name = DefaultProductName };
            newProductInputWrapper.BindingContext = newProduct;
        }



        public Command SaveCommand
        {
            get => (Command)GetValue(SaveCommandProperty);
            set => SetValue(SaveCommandProperty, value);
        }
        public static readonly BindableProperty SaveCommandProperty = BindableProperty.Create(
            nameof(SaveCommand),
            typeof(Command),
            typeof(NewProductCreationDialogView),
            new Command(() => throw new NotImplementedException()),
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (NewProductCreationDialogView)bindable;
                if (@new is Command command)
                    @this.SaveCommand = command;
            });

        public string DefaultProductName
        {
            get => (string)GetValue(DefaultProductNameProperty);
            set => SetValue(DefaultProductNameProperty, value);
        }
        public static readonly BindableProperty DefaultProductNameProperty = BindableProperty.Create(
            nameof(DefaultProductName),
            typeof(string),
            typeof(NewProductCreationDialogView),
            "Product",
            propertyChanged: (bindable, old, @new) =>
            {
                var @this = (NewProductCreationDialogView)bindable;
                if (@new is not string name)
                    return;

                @this.DefaultProductName = name;
                @this.NewProduct = new() { Name = name };

                @this.newProductInputWrapper.BindingContext = null;
                @this.newProductInputWrapper.BindingContext = @this.NewProduct; 
            });

        private void Button_Clicked(object sender, EventArgs e) => Save();

        public void Save() => SaveCommand.Execute(NewProduct);
    }
}
using ProjectNutrition.Models;
using ProjectNutrition.ViewModels;

namespace ProjectNutrition.Views
{
    public partial class NewMealCreationDialogView : ContentView
    {
        public NewMealCreationDialogViewModel VM { get; }
        public NewMealCreationDialogView()
        {
            InitializeComponent();

            VM = MauiProgram.GetService<NewMealCreationDialogViewModel>() ?? throw new NullReferenceException();
            (productSearchView.BindingContext as ProductSearchViewModel ?? throw new NullReferenceException()).OnProductSelected += VM.OnProductSelectedAsIngredient;

            wrapper.BindingContext = VM;
        }
    }
}
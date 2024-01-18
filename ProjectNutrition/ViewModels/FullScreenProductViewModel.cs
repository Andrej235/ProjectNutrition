using CommunityToolkit.Mvvm.ComponentModel;
using ProjectNutrition.Models;

namespace ProjectNutrition.ViewModels
{
    public partial class FullScreenProductViewModel : ObservableObject
    {
        [ObservableProperty]
        private Product? product;
    }
}

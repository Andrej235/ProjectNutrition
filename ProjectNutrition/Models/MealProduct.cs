using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectNutrition.Models
{
    /// <summary>
    /// Junction table for Meal and Product
    /// </summary>
    public class MealProduct : ObservableObject
    {
        public int Id { get; set; }

        public Meal Meal
        {
            get => meal;
            set => SetProperty(ref meal, value);
        }
        private Meal meal = null!;

        public Product Product
        {
            get => product;
            set => SetProperty(ref product, value);
        }
        private Product product = null!;

        public float Amount
        {
            get => amount;
            set => SetProperty(ref amount, value);
        }
        private float amount;

        public MealProduct(Meal meal, Product product, float amount)
        {
            Meal = meal;
            Product = product;
            Amount = amount;
        }

        public MealProduct(int id, Meal meal, Product product, float amount)
        {
            Id = id;
            Meal = meal;
            Product = product;
            Amount = amount;
        }
    }
}

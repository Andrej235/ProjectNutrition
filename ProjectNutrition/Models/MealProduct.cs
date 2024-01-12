using CommunityToolkit.Mvvm.ComponentModel;
using LocalJSONDatabase.Attributes;

namespace ProjectNutrition.Models
{
    /// <summary>
    /// Junction table for Meal and Product
    /// </summary>
    public class MealProduct : ObservableObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        [ForeignKey]
        public Meal Meal
        {
            get => meal;
            set => SetProperty(ref meal, value);
        }
        private Meal meal = null!;

        [ForeignKey]
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

        public MealProduct() { }

        public MealProduct(Meal meal, Product product) : this(0, meal, product, 0) { }

        public MealProduct(Meal meal, Product product, float amount) : this(0, meal, product, amount) { }

        public MealProduct(int id, Meal meal, Product product, float amount)
        {
            Id = id;
            Meal = meal;
            Product = product;
            Amount = amount;
        }
    }
}

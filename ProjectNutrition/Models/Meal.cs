using CommunityToolkit.Mvvm.ComponentModel;
using LocalJSONDatabase.Attributes;

namespace ProjectNutrition.Models
{
    public class Meal : ObservableObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private string name = null!;

        [ForeignKey]
        public IEnumerable<MealProduct> Products
        {
            get => products;
            set => SetProperty(ref products, value);
        }
        private IEnumerable<MealProduct> products = null!;

        public Meal()
        {
            name = "";
            products = [];
        }

        public Meal(int id, string name, IEnumerable<MealProduct> products)
        {
            Id = id;
            Name = name;
            Products = products;
        }

        public float GetCalories() => Products.Sum(x => x.Product.Calories * (x.Amount / 100));
        public float GetProtein() => Products.Sum(x => x.Product.Proteins * (x.Amount / 100));
        public float GetCarbs() => Products.Sum(x => x.Product.Carbs * (x.Amount / 100));
        public float GetFats() => Products.Sum(x => x.Product.Fats * (x.Amount / 100));
        public float GetFibers() => Products.Sum(x => x.Product.Fibers * (x.Amount / 100));
    }
}

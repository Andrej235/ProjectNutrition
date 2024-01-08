namespace ProjectNutrition.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<MealProduct> Products { get; set; } = new List<MealProduct>();
    }
}

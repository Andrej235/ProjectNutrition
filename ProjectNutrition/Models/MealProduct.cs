namespace ProjectNutrition.Models
{
    /// <summary>
    /// Junction table for Meal and Product
    /// </summary>
    public class MealProduct
    {
        public int Id { get; set; }
        public Meal Meal { get; set; } = null!;
        public Product Product { get; set; } = null!;
        public float Amount { get; set; }
    }
}

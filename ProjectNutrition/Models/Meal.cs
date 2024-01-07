namespace ProjectNutrition
{
    public static partial class MauiProgram
    {
        public class Meal
        {
            public int Id { get; set; }
            public string Name { get; set; } = string.Empty;
            public IEnumerable<MealIngredient> Ingredients { get; set; } = new List<MealIngredient>();
        }
    }
}

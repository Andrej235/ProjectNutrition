namespace ProjectNutrition
{
    public static partial class MauiProgram
    {
        /// <summary>
        /// Junction table for Meal and Ingredient
        /// </summary>
        public class MealIngredient
        {
            public int Id { get; set; }
            public Meal Meal { get; set; } = null!;
            public Ingredient Ingredient { get; set; } = null!;
            public float Amount { get; set; }
        }
    }
}

namespace ProjectNutrition
{
    public static partial class MauiProgram
    {
        /// <summary>
        /// Junction table for Day and Meal
        /// </summary>
        public class EatenMeal
        {
            public int Id { get; set; }
            public Meal Meal { get; set; } = null!;
            public Day Day { get; set; } = null!;
        }
    }
}

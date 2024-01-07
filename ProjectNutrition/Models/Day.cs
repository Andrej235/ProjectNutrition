namespace ProjectNutrition
{
    public static partial class MauiProgram
    {
        public class Day
        {
            public int Id { get; set; }
            public DateOnly Date { get; set; }
            public DailyGoal Goal { get; set; } = null!;
            public IEnumerable<EatenMeal> EatenMeals { get; set; } = new List<EatenMeal>();
            public IEnumerable<EatenProducts> EatenProducts { get; set; } = new List<EatenProducts>();
        }
    }
}

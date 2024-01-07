namespace ProjectNutrition
{
    public static partial class MauiProgram
    {
        /// <summary>
        /// Junction table for FinishedProduct and Day
        /// </summary>
        public class EatenProducts
        {
            public int Id { get; set; }
            public FinishedProduct Product { get; set; } = null!;
            public Day Day { get; set; } = null!;
        }
    }
}

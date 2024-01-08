namespace ProjectNutrition.Models
{
    /// <summary>
    /// Junction table for FinishedProduct and Day
    /// </summary>
    public class EatenProducts
    {
        public int Id { get; set; }
        public Product Product { get; set; } = null!;
        public Day Day { get; set; } = null!;
    }
}

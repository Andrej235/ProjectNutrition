namespace ProjectNutrition.Database.DTOs
{
    public record DailyGoalDTO(int Id, float Calories, float Proteins, float Carbs, float Fats, float Fibers);
    public record DayDTO(int Id, DateOnly Date, DailyGoalDTO Goal, IEnumerable<EatenMealDTO> EatenMeals, IEnumerable<EatenProductsDTO> EatenProducts);
    public record EatenMealDTO(int Id, MealDTO Meal, DayDTO Day);
    public record EatenProductsDTO(int Id, ProductDTO Product, DayDTO Day);
    public record MealDTO(int Id, string Name, IEnumerable<MealProductDTO> Products);
    public record MealProductDTO(int Id, MealDTO Meal, ProductDTO Product, float Amount);
    public record ProductDTO(int Id, string Name, float Calories, float Proteins, float Carbs, float Fats, float Fibers);
}

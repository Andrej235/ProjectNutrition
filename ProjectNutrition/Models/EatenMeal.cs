using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectNutrition.Models
{
    /// <summary>
    /// Junction table for Day and Meal
    /// </summary>
    public class EatenMeal : ObservableObject
    {
        public int Id { get; set; }

        public Meal Meal
        {
            get => meal;
            set => SetProperty(ref meal, value);
        }
        private Meal meal = null!;

        public Day Day
        {
            get => day;
            set => SetProperty(ref day, value);
        }
        private Day day = null!;

        public EatenMeal(Meal meal, Day day)
        {
            Meal = meal;
            Day = day;
        }

        public EatenMeal(int id, Meal meal, Day day)
        {
            Id = id;
            Meal = meal;
            Day = day;
        }
    }
}

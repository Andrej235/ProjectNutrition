using CommunityToolkit.Mvvm.ComponentModel;
using LocalJSONDatabase.Attributes;

namespace ProjectNutrition.Models
{
    /// <summary>
    /// Junction table for Day and Meal
    /// </summary>
    public class EatenMeal : ObservableObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        [ForeignKey]
        public Meal Meal
        {
            get => meal;
            set => SetProperty(ref meal, value);
        }
        private Meal meal = null!;

        [ForeignKey]
        public Day Day
        {
            get => day;
            set => SetProperty(ref day, value);
        }
        private Day day = null!;

        public EatenMeal() { }

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

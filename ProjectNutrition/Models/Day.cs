using CommunityToolkit.Mvvm.ComponentModel;
using LocalJSONDatabase.Attributes;

namespace ProjectNutrition.Models
{
    public class Day : ObservableObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public DateOnly Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }
        private DateOnly date;

        [ForeignKey]
        public DailyGoal Goal
        {
            get => goal;
            set => SetProperty(ref goal, value);
        }
        private DailyGoal goal = null!;

        [ForeignKey]
        public IEnumerable<EatenMeal> EatenMeals
        {
            get => eatenMeals;
            set => SetProperty(ref eatenMeals, value);
        }
        private IEnumerable<EatenMeal> eatenMeals = null!;

        [ForeignKey]
        public IEnumerable<EatenProducts> EatenProducts
        {
            get => eatenProducts;
            set => SetProperty(ref eatenProducts, value);
        }
        private IEnumerable<EatenProducts> eatenProducts = null!;

        public Day() { }

        public Day(DateOnly date, DailyGoal goal)
        {
            Date = date;
            Goal = goal;

            EatenMeals = [];
            EatenProducts = [];
        }

        public Day(DailyGoal goal) : this(DateOnly.FromDateTime(DateTime.Now), goal) { }

        public Day(int id, DateOnly date, DailyGoal goal, IEnumerable<EatenMeal> eatenMeals, IEnumerable<EatenProducts> eatenProducts)
        {
            Id = id;
            Date = date;
            Goal = goal;
            EatenMeals = eatenMeals;
            EatenProducts = eatenProducts;
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectNutrition.Models
{
    public class DailyGoal : ObservableObject
    {
        public int Id { get; set; }

        public float Calories
        {
            get => calories;
            set => SetProperty(ref calories, value);
        }
        private float calories;

        public float Proteins
        {
            get => proteins;
            set => SetProperty(ref proteins, value);
        }
        private float proteins;

        public float Carbs
        {
            get => carbs;
            set => SetProperty(ref carbs, value);
        }
        private float carbs;

        public float Fats
        {
            get => fats;
            set => SetProperty(ref fats, value);
        }
        private float fats;

        public float Fibers
        {
            get => fibers;
            set => SetProperty(ref fibers, value);
        }
        private float fibers;

        public DailyGoal() { }

        public DailyGoal(int id, float calories, float proteins, float carbs, float fats, float fibers)
        {
            Id = id;
            Calories = calories;
            Proteins = proteins;
            Carbs = carbs;
            Fats = fats;
            Fibers = fibers;
        }
    }
}

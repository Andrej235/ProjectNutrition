using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectNutrition.Models
{
    public class Product : ObservableObject
    {
        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private string name = "";

        /// <summary>
        /// In 100 grams
        /// </summary>
        public float Calories
        {
            get => calories;
            set => SetProperty(ref calories, value);
        }
        private float calories;

        ///<inheritdoc cref="Calories"/>
        public float Proteins
        {
            get => proteins;
            set => SetProperty(ref proteins, value);
        }
        private float proteins;

        ///<inheritdoc cref="Calories"/>
        public float Carbs
        {
            get => carbs;
            set => SetProperty(ref carbs, value);
        }
        private float carbs;

        ///<inheritdoc cref="Calories"/>
        public float Fats
        {
            get => fats;
            set => SetProperty(ref fats, value);
        }
        private float fats;

        ///<inheritdoc cref="Calories"/>
        public float Fibers
        {
            get => fibers;
            set => SetProperty(ref fibers, value);
        }
        private float fibers;
    }
}

namespace ProjectNutrition.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// In 100 grams
        /// </summary>
        public float Calories { get; set; }

        ///<inheritdoc cref="Calories"/>
        public float Proteins { get; set; }

        ///<inheritdoc cref="Calories"/>
        public float Carbs { get; set; }

        ///<inheritdoc cref="Calories"/>
        public float Fats { get; set; }

        ///<inheritdoc cref="Calories"/>
        public float Fibers { get; set; }
    }
}

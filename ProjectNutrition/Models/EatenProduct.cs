using CommunityToolkit.Mvvm.ComponentModel;

namespace ProjectNutrition.Models
{
    /// <summary>
    /// Junction table for FinishedProduct and Day
    /// </summary>
    public class EatenProducts : ObservableObject
    {
        public int Id { get; set; }

        public Product Product
        {
            get => product;
            set => SetProperty(ref product, value);
        }
        private Product product = null!;

        public Day Day
        {
            get => day;
            set => SetProperty(ref day, value);
        }
        private Day day = null!;

        public EatenProducts(Product product, Day day)
        {
            Product = product;
            Day = day;
        }

        public EatenProducts(int id, Product product, Day day)
        {
            Id = id;
            Product = product;
            Day = day;
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using LocalJSONDatabase.Attributes;

namespace ProjectNutrition.Models
{
    /// <summary>
    /// Junction table for FinishedProduct and Day
    /// </summary>
    public class EatenProducts : ObservableObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        [ForeignKey]
        public Product Product
        {
            get => product;
            set => SetProperty(ref product, value);
        }
        private Product product = null!;

        [ForeignKey]
        public Day Day
        {
            get => day;
            set => SetProperty(ref day, value);
        }
        private Day day = null!;

        public EatenProducts() { }

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

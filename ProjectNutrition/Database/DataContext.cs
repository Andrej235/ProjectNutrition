using LocalJSONDatabase.Core;
using LocalJSONDatabase.Services.ModelBuilder;
using ProjectNutrition.Models;

namespace ProjectNutrition.Database
{
    public class DataContext : DBContext
    {
        private string dbDirPath = "";

        public DataContext(ModelBuilder modelBuilder) : base(modelBuilder) => Initialize();

        protected override Task Initialize()
        {
            dbDirPath = FileSystem.AppDataDirectory;
            return base.Initialize();
        }

        protected override string DBDirectoryPath => dbDirPath;

        protected override void OnConfiguring(ModelBuilder modelBuilder)
        {
            modelBuilder.Model<MealProduct>()
                .HasOne(x => x.Product)
                .WithMany(x => x.UsedInMeals);

            modelBuilder.Model<MealProduct>()
                .HasOne(x => x.Meal)
                .WithMany(x => x.Products);
        }

        public DBTable<Product> Products { get; set; } = null!;
        public DBTable<DailyGoal> DailyGoals { get; set; } = null!;
        public DBTable<Meal> Meals { get; set; } = null!;
        public DBTable<MealProduct> MealProducts { get; set; } = null!;
        public DBTable<EatenMeal> EatenMeals { get; set; } = null!;
        public DBTable<EatenProducts> EatenProducts { get; set; } = null!;
        public DBTable<Day> Days { get; set; } = null!;
    }
}

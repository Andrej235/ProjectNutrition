using LocalJSONDatabase.Core;
using LocalJSONDatabase.Services.ModelBuilder;
using ProjectNutrition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectNutrition.Database
{
    public class DataContext(ModelBuilder modelBuilder) : DBContext(modelBuilder)
    {
        public static DataContext Context { get; private set; } = null!;
        private string dbDirPath = "";

        public override Task Initialize()
        {
            Context = this;
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

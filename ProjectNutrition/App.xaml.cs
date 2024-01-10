using ProjectNutrition.Database;

namespace ProjectNutrition
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            InitializeDB();
            var a = File.ReadAllText("/data/user/0/com.companyname.projectnutrition/files/ProjectNutrition.Models.Product.json");
        }

        private static async void InitializeDB() => await new DataContext(new()).Initialize();
    }
}

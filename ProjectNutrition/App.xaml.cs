using ProjectNutrition.Database;

namespace ProjectNutrition
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}

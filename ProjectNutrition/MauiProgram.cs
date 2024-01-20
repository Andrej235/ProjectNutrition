using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using LocalJSONDatabase.Services.ModelBuilder;
using Microsoft.Extensions.Logging;
using ProjectNutrition.Database;
using ProjectNutrition.Pages;
using ProjectNutrition.ViewModels;

namespace ProjectNutrition
{
    public static partial class MauiProgram
    {
        private static IServiceProvider serviceProvider = null!;
        public static TService? GetService<TService>() => serviceProvider.GetService<TService>();


        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseMauiCommunityToolkitCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<DataContext>();
            builder.Services.AddSingleton<ModelBuilder>();

            builder.Services.AddSingleton<ProductsPage>();
            builder.Services.AddSingleton<MealsPage>();
            builder.Services.AddSingleton<DailyGoalPage>();

            builder.Services.AddSingleton<ProductsViewModel>();
            builder.Services.AddSingleton<MealsViewModel>();
            builder.Services.AddSingleton<DailyGoalViewModel>();

            builder.Services.AddTransient<ProductSearchViewModel>();
            builder.Services.AddTransient<NewMealCreationDialogViewModel>();
            builder.Services.AddTransient<MealSearchViewModel>();
            builder.Services.AddTransient<FullScreenProductViewModel>();
            builder.Services.AddTransient<MealDisplayViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();
            serviceProvider = app.Services;

            return app;
        }
    }
}

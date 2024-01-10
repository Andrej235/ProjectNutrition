﻿using CommunityToolkit.Maui;
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

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}

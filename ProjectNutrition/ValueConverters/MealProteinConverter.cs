using ProjectNutrition.Models;
using System.Globalization;

namespace ProjectNutrition.ValueConverters
{
    public class MealProteinConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is not Meal meal)
                return null;

            return $"{meal.GetProtein():f0}";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => null;
    }
}

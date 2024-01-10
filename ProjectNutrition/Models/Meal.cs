﻿using CommunityToolkit.Mvvm.ComponentModel;
using LocalJSONDatabase.Attributes;

namespace ProjectNutrition.Models
{
    public class Meal : ObservableObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        private string name = null!;

        [ForeignKey]
        public IEnumerable<MealProduct> Products
        {
            get => products;
            set => SetProperty(ref products, value);
        }
        private IEnumerable<MealProduct> products = null!;

        public Meal()
        {
            name = "";
            products = [];
        }

        public Meal(int id, string name, IEnumerable<MealProduct> products)
        {
            Id = id;
            Name = name;
            Products = products;
        }
    }
}

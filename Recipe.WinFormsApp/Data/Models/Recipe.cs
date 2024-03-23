using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.WinFormsApp.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int TimeForPreparationInMinutes { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
        }
        public Recipe(string name, int timeForPreparationInMinutes, List<Ingredient> ingredients, string description, string imageURL)
        {
            Name = name;
            TimeForPreparationInMinutes = timeForPreparationInMinutes;
            Ingredients = ingredients;
            Description = description;
            ImageURL = imageURL;
        }
    }
}

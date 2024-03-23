using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.WinFormsApp.Data.Models
{
    public class Ingredient
    {
        public Ingredient(string name)
        {
            Name = name;
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public int RecipeId { get; set; }
        public Data.Models.Recipe Recipe { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.WinFormsApp.Exceptions
{
    public class RecipeNotFoundException : Exception
    {
        public RecipeNotFoundException() : base("Recipe not found.")
        { 
        }
    }
}

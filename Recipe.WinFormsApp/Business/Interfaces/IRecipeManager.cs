using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.WinFormsApp.Business.Interfaces
{
    public interface IRecipeManager
    {
        void Add(Data.Models.Recipe recipe);
        void RemoveById(int id);
        void Remove(Data.Models.Recipe recipe);
        Data.Models.Recipe GetRecipeById(int id);
        List<Data.Models.Recipe> GetRecipes();
    }
}

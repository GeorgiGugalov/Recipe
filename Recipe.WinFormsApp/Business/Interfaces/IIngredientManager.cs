using Recipe.WinFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.WinFormsApp.Business.Interfaces
{
    public interface IIngredientManager
    {
        Ingredient GetIngredientById(int id);
        Ingredient GetIngredientByName(string name);
        void Add(Ingredient ingredient);
        void RemoveById(int id);
        void Remove(Ingredient ingredient);
    }
}

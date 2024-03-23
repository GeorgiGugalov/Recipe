using Azure.Core;
using Recipe.WinFormsApp.Business.Interfaces;
using Recipe.WinFormsApp.Data;
using Recipe.WinFormsApp.Data.Models;
using Recipe.WinFormsApp.Exceptions;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.WinFormsApp.Business
{
    public class IngredientManager : IIngredientManager
    {
        public RecipeContext recipeContext { get; set; }
        public IngredientManager(RecipeContext recipeContext)
        {
            this.recipeContext = recipeContext;
        }

        public Ingredient GetIngredientById(int id)
        {
            using (recipeContext)
            {
                if (recipeContext.Ingredients.Any(i => i.Id == id))
                {
                    return recipeContext.Ingredients.First(i => i.Id == id);
                }
                throw new IngredientNotFoundException();
            }
        }

        public Ingredient GetIngredientByName(string name)
        {
            using (recipeContext)
            {
                if (recipeContext.Ingredients.Any(i => i.Name == name))
                {
                    return recipeContext.Ingredients.First(i => i.Name == name);
                }
                throw new IngredientNotFoundException();
            }
        }

        public void Add(Ingredient ingredient)
        {
            using (recipeContext)
            {
                recipeContext.Ingredients.Add(ingredient);
                recipeContext.SaveChanges();
            }
            throw new IngredientAlreadyExistsException();
        }

        public void RemoveById(int id)
        {
            using (recipeContext)
            {
                if (recipeContext.Ingredients.Any(i => i.Id == id))
                {
                    Ingredient ingredient = (Ingredient)recipeContext.Ingredients.Where(i => i.Id == id);
                    recipeContext.Ingredients.Remove(ingredient);
                    recipeContext.SaveChanges();
                }
                throw new IngredientNotFoundException();
            }
        }

        public void Remove(Ingredient ingredient)
        {
            using (recipeContext)
            {
                if (recipeContext.Ingredients.Any(i => i.Name == ingredient.Name))
                {
                    recipeContext.Ingredients.Remove(ingredient);
                    recipeContext.SaveChanges();
                }
                throw new IngredientNotFoundException();
            }
        }
    }
}

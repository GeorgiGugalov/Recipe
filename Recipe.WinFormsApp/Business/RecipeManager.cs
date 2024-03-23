using Azure.Core;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Recipe.WinFormsApp.Business.Interfaces;
using Recipe.WinFormsApp.Data;
using Recipe.WinFormsApp.Data.Models;
using Recipe.WinFormsApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.WinFormsApp.Business
{
    public class RecipeManager : IRecipeManager
    {
        RecipeContext recipeContext;

        public RecipeManager(RecipeContext context)
        {
            recipeContext = context;
        }

        public void Add(Data.Models.Recipe recipe)
        {
            using (recipeContext = new RecipeContext())
            {
                recipeContext.Recipes.Add(recipe);
                recipeContext.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the city with this ID from the database
        /// </summary>
        public void RemoveById(int id)
        {
            using (recipeContext = new RecipeContext())
            {
                var item = recipeContext.Recipes.Find(id);
                if (item != null)
                {
                    recipeContext.Recipes.Remove(item);
                    recipeContext.SaveChanges();
                }
            }
        }

        public void Remove(Data.Models.Recipe recipe)
        {
            using (recipeContext = new RecipeContext())
            {
                recipeContext.Recipes.Remove(recipe);
                recipeContext.SaveChanges();
            }
        }

        /// <summary>
        /// When given the ID, returns the city
        /// </summary>
        public Data.Models.Recipe GetRecipeById(int id)
        {
            using (recipeContext = new RecipeContext())
            {
                if (recipeContext.Recipes.Any(r => r.Id == id))
                {
                    return recipeContext.Recipes.Find(id);
                }
                throw new RecipeNotFoundException();
            }
        }
        /// <summary>
        /// Returns all cities currently in the database
        /// </summary>
        public List<Data.Models.Recipe> GetRecipes()
        {
            using (recipeContext = new RecipeContext())
            {
                if (recipeContext.Recipes.Any())
                {
                    return recipeContext.Recipes.ToList();
                }
                return new List<Data.Models.Recipe>();
            }

        }
        /// <summary>
        /// Updates the old city with the new city
        /// </summary>
        
        //public void Update(City city)
        //{
        //    using (travelAgencyContext = new TravelAgencyContext())
        //    {
        //        var item = travelAgencyContext.Cities.Find(city.Id);
        //        if (item != null)
        //        {
        //            travelAgencyContext.Entry(item).CurrentValues.SetValues(city);
        //            travelAgencyContext.SaveChanges();
        //        }
        //    }
        //}

    }
}
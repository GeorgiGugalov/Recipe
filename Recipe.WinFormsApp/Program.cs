using Microsoft.EntityFrameworkCore;
using Recipe.WinFormsApp.Business;
using Recipe.WinFormsApp.Data;
using Recipe.WinFormsApp.Forms;
using Recipe.WinFormsApp.Migrations;
using System.Data.Common;

namespace Recipe.WinFormsApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using (RecipeContext recipeContext = new RecipeContext())
            {
                MainForm mainForm = new MainForm(new RecipeManager(recipeContext), new IngredientManager(recipeContext), recipeContext);
                Application.Run(mainForm);
            }
        }
    }
}
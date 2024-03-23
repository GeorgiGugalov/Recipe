using Recipe.WinFormsApp.Business;
using Recipe.WinFormsApp.Data;
using Recipe.WinFormsApp.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe.WinFormsApp.Forms
{
    public partial class AddRecipeForm : Form
    {
        public RecipeManager recipeManager { get; set; }

        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string Discription { get; set; }
        public int PreparationTimeInMinutes { get; set; }
        public string ImageURL { get; set; }
        public AddRecipeForm(RecipeContext RecipeContext)
        {
            InitializeComponent();
            recipeManager = new RecipeManager(RecipeContext);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            recipeManager.Add(new Data.Models.Recipe(Name, PreparationTimeInMinutes, Ingredients, Discription, ImageURL));
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            this.PreparationTimeInMinutes = int.Parse(textBox4.Text);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.Discription = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3 != null)
            {
                string textBoxText = textBox1.Text;

                // Split the text by ", " and convert it into an array
                string[] parts = textBoxText.Split(new string[] { ", " }, StringSplitOptions.None);

                // Convert the array to a List of Ingredients
                List<Ingredient> resultList = new List<Ingredient>();
                foreach (string item in parts)
                {
                    // Assuming Ingredient has a constructor that takes a string as an argument
                    Ingredient ingredient = new Ingredient(item);
                    this.Ingredients.Add(ingredient);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Name = textBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            this.ImageURL = textBox5.Text;
        }
    }
}

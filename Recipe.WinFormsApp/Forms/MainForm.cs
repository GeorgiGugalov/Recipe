using Recipe.WinFormsApp.Business.Interfaces;
using Recipe.WinFormsApp.Data;
using Recipe.WinFormsApp.Data.Models;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace Recipe.WinFormsApp.Forms
{
    public class MainForm : Form
    {
        public IRecipeManager recipeManager { get; set; }
        public IIngredientManager ingredientManager { get; set; }
        public RecipeContext recipeContext { get; set; }
        public MainForm(IRecipeManager recipeManager, IIngredientManager ingredientManager, RecipeContext recipeContext)
        {
            InitializeComponent();
            this.recipeManager = recipeManager;
            this.ingredientManager = ingredientManager;
            this.recipeContext = recipeContext;
        }
        private void InitializeUI()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Dock = DockStyle.Fill;

            //Button button = new Button();
            //button.Text = $"Button {i}";
            //flowLayoutPanel.Controls.Add(button);
            List<Ingredient> ingr = new List<Ingredient>();
            Data.Models.Recipe recipe = new Data.Models.Recipe("Musaka", 120,
                new List<Ingredient>(){ ingredientManager.GetIngredientByName("Potato"),
                                        ingredientManager.GetIngredientByName("Mince"),
                                        ingredientManager.GetIngredientByName("Onion") }, null, null);
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(707, 12);
            button1.Name = "button1";
            button1.Size = new Size(128, 44);
            button1.TabIndex = 0;
            button1.Text = "Add Recipe";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MainForm
            // 
            ClientSize = new Size(847, 493);
            Controls.Add(button1);
            Name = "MainForm";
            ResumeLayout(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRecipeForm addRecipeForm = new AddRecipeForm(recipeContext);
            addRecipeForm.Show();

            //Data.Models.Recipe recipe = new Data.Models.Recipe
        }

        private Button button1;
    }
}

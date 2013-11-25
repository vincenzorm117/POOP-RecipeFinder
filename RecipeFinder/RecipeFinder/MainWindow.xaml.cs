using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using System.IO;


namespace RecipeFinder
{
    /**
     * \class MainWindow
     * \brief The class for the main program and it's main execution
     **/
    public partial class MainWindow : Window
    {
        /**
         * \fn      public MainWindow()
         * \brief   Class constructor for initializing the program.
         **/
        public MainWindow()
        {   
            _selectedMode = CookMode.NONE;

            /*File Input Functionality Here*/
            if(!AllergyInput("../../Inputs/inputAllergies.txt"))
                return;

            if(!IngredientInput("../../Inputs/inputIngredients.txt"))
                return;
            IngredientSplit();

            if(!RecipeInput("../../Inputs/inputRecipes.txt"))
                return;

            //Recipe input functionality will be placed here.....WHEN I FUCKING FEEL LIKE IT.
            //  Sincerely, The Coding Taskmaster!

            /*End Input Functionality Here*/

            InitializeComponent();
            populateAllergies();
            populateFilterExpandersAndCheckBoxes();
        }

        /**
         * \fn private void updateRecipeSelection(object sender, SelectionChangedEventArgs e)
         * \param sender
         * \param e
         **/
        private void updateRecipeSelection(object sender, SelectionChangedEventArgs e) {
            ListBox s = (ListBox)e.Source;

            if (s != null)
                if (s.Items.Count > 0) {
                    
                    String x = s.SelectedItem.ToString();
                    DisplayTitle.Text = x;

                    Recipe r = (Recipe)_selections[x];

                    DisplayTime.Text = String.Format("Total Time: {0}  Preparation Time: {1}", r.getTotalTime(), r.getPrepTime());

                    StringBuilder displayedIngredients = new StringBuilder();

                    foreach (RecipeFinder.Recipe.ingredientData d in r.getIngredients()) {
                       displayedIngredients.Append(String.Format("{0} {1} {2}\n", d._amount, getTextMeasurement(d._measurement), _CategoryLists[d._categoryID][d._categoryIndex].getName()));
                    }
                    DisplayIngredients.Text = displayedIngredients.ToString();

                    DisplayServings.Text    = String.Format("{0}", r.getServings());
                    DisplayCalories.Text    = String.Format("{0} (kcal)", r.getCalories());
                    DisplayFat.Text         = String.Format("{0} (g)", r.getFat());
                    DisplayCholeterol.Text  = String.Format("{0} (mg)", r.getCholestoral());
                    DisplaySodium.Text      = String.Format("{0} (g)", r.getSodium());
                    DisplayCarbs.Text       = String.Format("{0} (g)", r.getCarbs());
                    DisplayFiber.Text       = String.Format("{0} (g)", r.getFiber());
                    DisplayProtein.Text     = String.Format("{0} (g)", r.getProtein());

                    DispLayInstructions.Text = r.getInstructions();

                }
        }




        /**
         * \fn private void print(object sender, RoutedEventArgs e)
         * \param sender
         * \param e
         **/
        private void print(object sender, RoutedEventArgs e) {
            PrintDialog dialog = new PrintDialog();

            if (dialog.ShowDialog() == true) {
                _printThickness.Left = 10;
                RecipeInformation.Margin = _printThickness;

                dialog.PrintVisual(RecipeInformation, DisplayTitle.Text);
                
                _printThickness.Left = 190;
                RecipeInformation.Margin = _printThickness;

            }
            
        }




        private void showFoodSafetyModule(object sender, RoutedEventArgs e) {
            if (p == null || !p.IsVisible) {
                p = new RecipeFinder.GUI.FoodSafetyModule();
                p.Show();
            }
        }



        

        
    }
}

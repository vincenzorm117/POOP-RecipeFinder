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
            _AllergyCounter = 0;

            /*File Input Functionality Here*/
            if(!AllergyInput("../../Inputs/inputAllergies.txt"))
                return;

            if(!IngredientInput("../../Inputs/inputIngredients.txt"))
                return;
            IngredientSplit();

            if(!RecipeInput("../../Inputs/inputRecipes.txt"))
                return;
            /*End Input Functionality Here*/

            InitializeComponent();
            populateAllergies();
            populateFilterExpandersAndCheckBoxes();
        }

        /**
         * \fn         private void showFoodSafetyModule(object sender, RoutedEventArgs e)
         * \brief      Function used for showing the user the food safety module.
         * \author     Vincenzo Marconi
         * \param [in] sender
         * \param [in] e
         **/
        private void showFoodSafetyModule(object sender, RoutedEventArgs e)
        {
            if (_p == null || !_p.IsVisible)
            {
                _p = new RecipeFinder.GUI.FoodSafetyModule();
                _p.Show();
            }
        }



        

        
    }
}

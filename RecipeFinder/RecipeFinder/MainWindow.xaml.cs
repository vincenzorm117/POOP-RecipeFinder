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
        private List<List<bool>> checkedIngredients;
        private CookMode selectedMode;

        /**
         * \fn      public MainWindow()
         * \brief   Class constructor for initializing the program.
         **/
        public MainWindow()
        {   
            selectedMode = CookMode.NONE;

            /*File Input Functionality Here*/
            if(!AllergyInput("../../Inputs/inputAllergies.txt"))
                return;

            if(!IngredientInput("../../Inputs/inputIngredients.txt"))
                return;
            IngredientSplit();

            //Recipe input functionality will be placed here.....WHEN I FUCKING FEEL LIKE IT.
            //  Sincerely, The Coding Taskmaster!

            /*End Input Functionality Here*/

            checkedIngredients = new List<List<bool>>();
            InitializeComponent();
            populateAllergies();
            populateFilterExpandersAndCheckBoxes();
        }

        /**
         * \fn private void updateRecipeSelection(object sender, SelectionChangedEventArgs e)
         * \param sender
         * \param e
         **/
        private void updateRecipeSelection(object sender, SelectionChangedEventArgs e)
        {
            RecipeDisplayed.Document.Blocks.Clear();
            ListBox s = (ListBox)e.Source;

            if(s != null)
                if (s.Items.Count > 0)
                {
                    //TODO: fix it so that if a box is selected make it true
                    String x = s.SelectedItem.ToString();
                    RecipeDisplayed.Document.Blocks.Add(new Paragraph(new Run(x)));
                }
        }

        /**
         * \fn private void print(object sender, RoutedEventArgs e)
         * \param sender
         * \param e
         **/
        private void print(object sender, RoutedEventArgs e)
        { /*Don't Touch this unless your handling view*/ }
    }
}

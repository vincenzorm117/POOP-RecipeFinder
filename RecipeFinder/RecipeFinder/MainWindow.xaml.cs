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
    //Enum declarations for use on ingredient categories, measurements
    //TODO: Add comment documentation once finally filled out
    public enum IngredientCategory {NONE, DAIRY, MEAT, VEGITABLES, FRUIT, SPICES};
    public enum Measurements       {NONE, TEASPOON, TABLESPOON, CUP, HALFCUP};
    public enum CookMode           {NONE, EASY, MIDDLE, CHEF};

    /**
     * \class MainWindow
     * \brief The class for the main program and it's main execution
     **/
    public partial class MainWindow : Window
    {
        private HashSet<String> checkedIngredients;

        /**
         * \fn      public MainWindow()
         * \brief   Class constructor for initializing the program.
         **/
        public MainWindow()
        {   
            /*File Input Function Here*/

            checkedIngredients = new HashSet<String>();
            InitializeComponent();
            populateAllergies();
            populateFilterExpandersAndCheckBoxes();
        }

        private void updateRecipeSelection(object sender, SelectionChangedEventArgs e)
        {
            RecipeDisplayed.Document.Blocks.Clear();
            ListBox s = (ListBox)e.Source;

            if(s != null)
                if (s.Items.Count > 0)
                {
                    String x = s.SelectedItem.ToString();
                    RecipeDisplayed.Document.Blocks.Add(new Paragraph(new Run(x)));
                }
        }

        private void print(object sender, RoutedEventArgs e)
        { /*Don't Touch this unless your handling view*/ }
    }
}

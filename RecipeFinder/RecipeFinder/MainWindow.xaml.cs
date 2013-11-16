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
    enum IngredientCategory {None};
    enum Measurements       {None};

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

         /**
         * \fn    public void populateFilterExpandersAndCheckBoxes()
         * \brief Used for creating the expanders and their check boxes
         **/
        public void populateFilterExpandersAndCheckBoxes()
        {
            //First for loop creates the expanders with its corresponding UniformGrid
            for(int i = 1; i < 11; i++)
            {
                //Expanders are the collapsable panel
                Expander e = new Expander();
                e.Header = "Expander " + i; //Sets the name of the Expander

                //Expanders have content but cannot store elements directly; it needs a grid to hold items
                //UniformGrid is the Expanders items container; what is unique about this grid is that it can columns and rows
                UniformGrid g = new UniformGrid();
                g.Columns = 2;  // The number of columns are set to 2 so it has 2 columns of checkboxes

                for(int j = 1; j < 11; j++)
                {
                    CheckBox c = new CheckBox();            //CheckBox created
                    c.Content = "CheckBox " + i + ":" + j; //Its name is set

                    //Adds actionlistener below (check_Box_Checked_Event) to current checkbox. So when the checkbox is selected that method is ran
                    c.Checked += check_Box_Checked_Event;
                    c.Unchecked += check_Box_Unchecked_Event;

                    //Checkbox is added to the UniformGrid so it can be inside the expander
                    g.Children.Add(c);

                }

                //The Expanders content is specified to be the current grid; comment out this line and see what happens
                e.Content = g;
                //The Current loops expander is added to the SearchFilters panel where they are placed in a stack manner because the panel is a StackPanel
                SearchFilters.Children.Add(e);
            }
        }

        void check_Box_Checked_Event(object sender, RoutedEventArgs e)
        {
            CheckBox c = (CheckBox)e.Source;
            checkedIngredients.Add((String)c.Content);
        }

        void check_Box_Unchecked_Event(object sender, RoutedEventArgs e)
        {
            CheckBox c = (CheckBox)e.Source;
            checkedIngredients.Remove((String)c.Content);
        }

        public void populateAllergies()
        {
            for(int i = 1; i < 11; i++)
            {
                CheckBox c = new CheckBox();
                c.Content  = "Allergy" + i;

                c.Checked   += check_Box_Checked_Event;
                c.Unchecked += check_Box_Unchecked_Event;

                this.Allergies.Children.Add(c);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        { 
            //View Properties Dont touch
            ControlTemp.Visibility  = System.Windows.Visibility.Hidden;
            SearchPanel.Visibility  = System.Windows.Visibility.Hidden;
            ResultsPanel.Visibility = System.Windows.Visibility.Visible;

            //List of parameters the user has searched for
            HashSet<String>.Enumerator list = checkedIngredients.GetEnumerator();

            //Empty list each time
            Results.Items.Clear();
            while(list.MoveNext())
            {
                //Send the user parameters
                //TODO: Update function call so that it fits with updated data storage methods
                //searchForRecipies(userSearchParams, recipeList, cookingMode,  alergens);

                while(list.MoveNext())
                {
                    String curr = list.Current;
                    Results.Items.Add(curr);
                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //View Properties Dont Touch
            ControlTemp.Visibility  = System.Windows.Visibility.Visible;
            SearchPanel.Visibility  = System.Windows.Visibility.Visible;
            ResultsPanel.Visibility = System.Windows.Visibility.Hidden;
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

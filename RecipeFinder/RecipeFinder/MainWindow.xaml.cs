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
    public partial class MainWindow : Window
    {
        private HashSet<String> checkedIngredients;
        
        public MainWindow()
        {   
            /*File Input Function Here*/

            checkedIngredients = new HashSet<String>();
            InitializeComponent();
            populateAllergies();
            populateFilterExpandersAndCheckBoxes();
        }

        public void populateFilterExpandersAndCheckBoxes()
        {
            //First for loop creates the expanders with its corresponding UniformGrid
            for(int i = 1; i < 11; i ++)
            {
                //Expanders are the collapsable panel
                Expander e = new Expander();
                e.Header   = "Expander " + i; //Sets the name of the Expander

                //Expanders have content but cannot store elements directly; it needs a grid to hold items
                //UniformGrid is the Expanders items container; what is unique about this grid is that it can columns and rows
                UniformGrid g = new UniformGrid();
                g.Columns     = 2;  // The number of columns are set to 2 so it has 2 columns of checkboxes

                for (int j = 1; j < 11; j++)
                {
                    CheckBox c = new CheckBox();            //CheckBox created
                    c.Content  = "CheckBox " + i + ":" + j; //Its name is set

                    //Adds actionlistener below (check_Box_Checked_Event) to current checkbox. So when the checkbox is selected that method is ran
                    c.Checked   += check_Box_Checked_Event;
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
                searchForRecipies(userSearchParams[][], recipeList[], cookingMode,  alergens[]);

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


        //Returns nothing for now
        //Based on discussion from 11/13/13
        //Input: take in the user's search parameters and the list of recipes.
        //          each recipe should have it's own 2d array of bools,
        //          an array of recipes,
        //          an integer representing the cooking mode,
        //          a bool array representing the different allergens
        //TODO: Remove hardcoded values from this function
        //TODO: Testing needs to be performed for this method once final touches have been added in
        public Recipe[] searchForRecipies(bool userSearchParams[][], Recipe recipeList[], int cookingMode,  bool alergens[])
        {
            
            //Recipe needs to be some sort of accessable object
            //Struct to keep track of the correct hits each recipe gets based on the search
            struct recipeMatches 
            {
                Recipe result;
                int hitCounter;
            }

            //Hard code in the number of catagories of ingrediants and the number per each
            int categories  = 8;
            int ingrediants = 12;

            //Array of the structs
            // Based on 100 recipe input
            recipeMatches recipeResults[] = new recipeMatches[100];
            //The return for the results for the top 10 of the search
            Recipe results[] = new Recipe[10];

            //Grab each ingrediant list from each recipe
            bool recipeIngrediants[][] = new bool [categories][ingrediants];
            
            int k;

            //First use the filters to remove any that match (i.e. milk alergy skip that record
            //Loop throughout the list of recipes
            for(int i = 0; i < 100; i++)
            {
                //Reset counter
                k = 0;

                //Check if the recipe has the alergen
                if (recipeList[i].alergen == true) 
                    continue;

                //Check to see if the recipe meets the correct 'mode'
                else if (recipeList[i].mode.containsEqualIgnoreCase(mode))
                {
                    //Grab the current recipe's list of ingredientes (again full list with true/false)
                    recipeIngredients = recipeList[i].ingrediantList;

                    //As we have flitered out hte recipes that we didn't want so we continue of filtering
                    for(int j = 0; j < categories; j ++ )
                    {
                        //Checing that both the user's and the recipie have the same category
                        if ((recipeIngredients[j][] == 1) && (userSeachParams[j][] == 1))
                            for (int s = 0; s < ingrediants; s++)
                            {
                                if ((recipeIngredients[j][s] == 1) && (userSeachParams[j][s] == 1))
                                    k = k + 1;
                            }
                    }

                    //Add the recipe to the results array setting the hit counter
                    recipeResults[i].recipe = recipeList[i].recipeId;
                    recipeResults[i].hitCounter = k;
                }
                //We have hit things we don't want so continue
                else
                    continue;
            }

            //Here we would order the results based on each recipe's hit counter
            Array.Sort(recipeResults);
            
            //Reverse the results as it is in ascending order
            Array.Reverse(recipeResults);

            //Grab the first 10
            Array.Copy(recipeResults, results, 10);

            //return the top 10
            return results;
        }
       
        private void print(object sender, RoutedEventArgs e)
        { /*Don't Touch this unless your handling view*/ }
    }
}

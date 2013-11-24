using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Collections.Generic;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        /**
         * \fn     private void SearchButton_Click(object sender, RoutedEventArgs e)
         * \brief  Handles the functionality of when the search button is clicked.
         * \author Vincenzo Marconi
         * \param  sender
         * \param  e
         **/
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            List<recipeMatches> results = searchForRecipies();

            //Hides the initially shown panels and shows the results panel
            ControlTemp.Visibility  = System.Windows.Visibility.Hidden;
            SearchPanel.Visibility  = System.Windows.Visibility.Hidden;
            ResultsPanel.Visibility = System.Windows.Visibility.Visible;

            //Current means of displaying the users selections
            //This section of code will be removed when Ronnies search function is finished
            /*for (int i = 0; i < Enum.GetNames(typeof(IngredientCategory)).Length; i++)
            {
                for (int j = 0; j < _CategoryLists[i].ToArray().Length; j++)
                {
                    bool curr = _UserSelections[i][j];
                    Results.Items.Add(curr);
                }
            }*/

            foreach(recipeMatches r in results)
            {
                Results.Items.Add(_recipeList[r.recipeIndex].getName());
            }
        }

        /**
         * \fn    private void Back_Click(object sender, RoutedEventArgs e)
         * \brief Handles the functionality of when the back button is clicked
         * \param sender
         * \param e
         **/
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //Sets the views back to the original view the program had when it first started up
            ControlTemp.Visibility  = System.Windows.Visibility.Visible;
            SearchPanel.Visibility  = System.Windows.Visibility.Visible;
            ResultsPanel.Visibility = System.Windows.Visibility.Hidden;

            //Empty list each time the user returns to the search parameters view
            Results.Items.Clear();
        }
    }
}
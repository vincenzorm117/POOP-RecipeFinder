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
         * \fn    private void SearchButton_Click(object sender, RoutedEventArgs e)
         * \brief Handles the functionality of when the search button is clicked.
         * \ author Vincenzo Marconi
         * \param sender
         * \param e
         * \ author Vincenzo Marconi
         **/
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //View Properties Dont touch
            ControlTemp.Visibility = System.Windows.Visibility.Hidden;
            SearchPanel.Visibility = System.Windows.Visibility.Hidden;
            ResultsPanel.Visibility = System.Windows.Visibility.Visible;
            int i, j;

            //Empty list each time
            Results.Items.Clear();

            for (i = 0; i < Enum.GetNames(typeof(IngredientCategory)).Length; i++)
            {
                //Send the user parameters
                //TODO: Update function call so that it fits with updated data storage methods
                for (j = 0; j < _CategoryLists[i].ToArray().Length; j++)
                {
                    bool curr = checkedIngredients[i][j];
                    Results.Items.Add(curr);
                }
            }

            //TODO: find these values for input
            searchForRecipies(allergens);
        }

        /**
         * \fn    private void Back_Click(object sender, RoutedEventArgs e)
         * \brief Handles the functionality of when the back button is clicked
         * \param sender
         * \param e
         **/
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //View Properties Dont Touch
            ControlTemp.Visibility = System.Windows.Visibility.Visible;
            SearchPanel.Visibility = System.Windows.Visibility.Visible;
            ResultsPanel.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
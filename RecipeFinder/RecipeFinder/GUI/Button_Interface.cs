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
         * \param sender
         * \param e
         **/
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            //View Properties Dont touch
            ControlTemp.Visibility = System.Windows.Visibility.Hidden;
            SearchPanel.Visibility = System.Windows.Visibility.Hidden;
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
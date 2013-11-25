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

            if (results.Count > 0)
            {
                TheWindow.Height = 531;
                TheWindow.MaxHeight = 531;

                if (_selections == null)
                    _selections = new System.Collections.Hashtable();

                _selections.Clear();

                //Hides the initially shown panels and shows the results panel
                ControlTemp.Visibility = System.Windows.Visibility.Hidden;
                SearchPanel.Visibility = System.Windows.Visibility.Hidden;
                ResultsPanel.Visibility = System.Windows.Visibility.Visible;

                foreach (recipeMatches r in results)
                {
                    Results.Items.Add(_recipeList[r.recipeIndex].getName());
                    _selections[_recipeList[r.recipeIndex].getName()] = _recipeList[r.recipeIndex];
                }

                Results.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No Results");
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

            TheWindow.MaxHeight = Double.PositiveInfinity;
            //Sets the views back to the original view the program had when it first started up
            ControlTemp.Visibility  = System.Windows.Visibility.Visible;
            SearchPanel.Visibility  = System.Windows.Visibility.Visible;
            ResultsPanel.Visibility = System.Windows.Visibility.Hidden;

            //Empty list each time the user returns to the search parameters view
            Results.Items.Clear();
        }
    }
}
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        /**
         * \fn    void check_Box_Checked_Event(object sender, RoutedEventArgs e)
         * \brief Function for handling the functionality of when a check box is checked by the user.
         * \param sender
         * \param e
         **/
        void check_Box_Checked_Event(object sender, RoutedEventArgs e)
        {
            IngredientCheckBox c = (IngredientCheckBox)e.Source;
            int column = c.getColumn();
            int row = c.getRow();
            _CategoryBooleans[column][row] = true;
        }

        /**
         * \fn    void check_Box_Unchecked_Event(object sender, RoutedEventArgs e)
         * \brief Function for handling the functionality of when a check box is unchecked by the user.
         * \param sender
         * \param e
         **/
        void check_Box_Unchecked_Event(object sender, RoutedEventArgs e)
        {
            IngredientCheckBox c = (IngredientCheckBox)e.Source;
            int column = c.getColumn();
            int row = c.getRow();
            _CategoryBooleans[column][row] = false;
        }
    }
}
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        /**
         * \fn    void checkBox_Clicked(object sender, RoutedEventArgs e)
         * \brief Function for handling the functionality of when a check box is unchecked or checked by the user.
         * \param sender
         * \param e
         **/
        void ingredient_Checked(object sender, RoutedEventArgs e)
        {
            IngredientCheckBox c = (IngredientCheckBox)e.Source;
            int column           = c.getColumn();
            int row              = c.getRow();
            _UserSelections[column][row] = !_UserSelections[column][row];
        }


    }
}
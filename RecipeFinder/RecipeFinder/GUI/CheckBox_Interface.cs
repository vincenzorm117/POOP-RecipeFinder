using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        /**
         * \fn    void ingredient_Checked(object sender, RoutedEventArgs e)
         * \brief Function for handling the functionality of when an ingredient check box is selected by the user.
         * \param sender
         * \param e
         **/
        void ingredient_Checked(object sender, RoutedEventArgs e)
        {
            IngredientCheckBox i = (IngredientCheckBox)e.Source;
            int column           = i.getColumn();
            int row              = i.getRow();
            _UserSelections[column][row] = !_UserSelections[column][row];
        }

        /**
         * \fn    void allergy_Checked(object sender, RoutedEventArgs e)
         * \brief Function for handling the functionality of when an allergy check box is selected by the user.
         * \param sender
         * \param e
         **/
        void allergy_Checked(object sender, RoutedEventArgs e)
        {
            AllergyCheckBox a = (AllergyCheckBox)e.Source;
            int index         = a.getIndex();
            _UsersAllergies[index] = !_UsersAllergies[index];
        }
    }
}
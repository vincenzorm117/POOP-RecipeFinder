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
         * \fn     private void MODENONE_Checked(object sender, RoutedEventArgs e)
         * \brief  Sets the selected cooking mode to the "NONE" enum value.
         * \author Ronald Hyatt
         * \param  sender
         * \param  e
         **/
        private void MODENONE_Checked(object sender, RoutedEventArgs e)
        {
            _selectedMode = CookMode.NONE;
        }

        /**
         * \fn     private void MODEQUICKANDEASY_Checked(object sender, RoutedEventArgs e)
         * \brief  Sets the selected cooking mode to the "QUICKANDEASY" enum value.
         * \author Ronald Hyatt
         * \param  sender
         * \param  e
         **/
        private void MODEQUICKANDEASY_Checked(object sender, RoutedEventArgs e)
        {
            _selectedMode = CookMode.QUICKANDEASY;
        }

        /**
         * \fn     private void MODEINTERMEDIATE_Checked(object sender, RoutedEventArgs e)
         * \brief  Sets the selected cooking mode to the "INTERMEDIATE" enum value.
         * \author Ronald Hyatt
         * \param  sender
         * \param  e
         **/
        private void MODEINTERMEDIATE_Checked(object sender, RoutedEventArgs e)
        {
            _selectedMode = CookMode.INTERMEDIATE;
        }

        /**
         * \fn     private void MODECHEF_Checked(object sender, RoutedEventArgs e)
         * \brief  Sets the selected cooking mode to the "CHEF" enum value.
         * \author Ronald Hyatt
         * \param  sender
         * \param  e
         **/
        private void MODECHEF_Checked(object sender, RoutedEventArgs e)
        {
            _selectedMode = CookMode.CHEF;
        }

    }

}




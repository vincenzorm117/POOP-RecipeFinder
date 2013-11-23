using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Collections.Generic;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {

        private void MODENONE_Checked(object sender, RoutedEventArgs e)
        {
            _selectedMode = CookMode.NONE;
        }

        private void MODEQUICKANDEASY_Checked(object sender, RoutedEventArgs e)
        {
            _selectedMode = CookMode.QUICKANDEASY;
        }

        private void MODEINTERMEDIATE_Checked(object sender, RoutedEventArgs e)
        {
            _selectedMode = CookMode.INTERMEDIATE;
        }

        private void MODECHEF_Checked(object sender, RoutedEventArgs e)
        {
            _selectedMode = CookMode.CHEF;
        }

    }

}




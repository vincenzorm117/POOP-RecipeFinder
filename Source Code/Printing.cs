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
        /**
         * \fn    private void print(object sender, RoutedEventArgs e)
         * \param sender
         * \param e
         **/
        private void print(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            _printThickness = new Thickness(10);

            if (dialog.ShowDialog() == true)
            {
                _printThickness.Left     = 10;
                RecipeInformation.Margin = _printThickness;

                dialog.PrintVisual(RecipeInformation, DisplayTitle.Text);
                
                _printThickness.Left     = 190;
                RecipeInformation.Margin = _printThickness;
            }
            
        }
    }
}
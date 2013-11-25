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
using System.Windows.Shapes;

namespace RecipeFinder.GUI
{
    /**
     * \class  FoodSafetyModule
     * \brief  Class for holding the food safety module.
     * \author Vincenzo Marconi
     **/
    public partial class FoodSafetyModule : Window
    {
        /**
         * \fn     public FoodSafetyModule()
         * \brief  Constructor for the food safety module class.
         * \author Vincenzo Marconi
         **/
        public FoodSafetyModule()
        {
            InitializeComponent();
        }

        /**
         * \fn         private void close(object sender, RoutedEventArgs e)
         * \brief      Function for handling the functionality of closing the gui for this class.
         * \author     Vincenzo Marconi
         * \param [in] sender
         * \param [in] e
         **/
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

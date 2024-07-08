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

namespace ProofOfConcept
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            init_Invisible(); //set page 2 as invisible

            List_Box_Pop(); //populate the recipe list results (DEBUG)
        }

        private void List_Box_Pop()
        {
            RecipeViewer.Content = "iCount";

            //Generate a random number
            Random number = new Random();
            int num = number.Next(20);
            //RecipeViewer.Content = num.ToString();
            List<ListBoxItem> items = new List<ListBoxItem>();
            //Create that many listboxitems
            for (int i = 0; i < num; i++)
            {
                ListBoxItem temp = new ListBoxItem();

                //Fill them with useful information
                if (i == 1) temp.Content = "1 Bat";

                else temp.Content = i + " Bats";

                //handlers
                RecipeList.Items.Add(temp);

            }
        }

        private void init_Invisible()
        {
            ResultsPage.Visibility = System.Windows.Visibility.Hidden;
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            SearchPage.Visibility = System.Windows.Visibility.Hidden;
            ResultsPage.Visibility = System.Windows.Visibility.Visible;
        }

        private void Go_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            SearchPage.Visibility = System.Windows.Visibility.Visible;
            ResultsPage.Visibility = System.Windows.Visibility.Hidden;
        }

        private void RecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem temp = (ListBoxItem)RecipeList.SelectedItem;
            RecipeViewer.Content = temp.Content;
        }

        private void Print_Click(object sender, RoutedEventArgs e) {
            PrintDialog men = new PrintDialog();

            if( men.ShowDialog() == true )
                men.PrintVisual(this.RecipeViewer, (String)this.RecipeViewer.Content);
            
        }
    }
}

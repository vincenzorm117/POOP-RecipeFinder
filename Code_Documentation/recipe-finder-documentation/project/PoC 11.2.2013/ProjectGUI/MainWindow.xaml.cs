namespace ProofOfConcept
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
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

    public delegate void RoutedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<check_Box_Expanded> check_Box_Array;

        public MainWindow()
        {
            InitializeComponent();

            check_Box_Array = new List<check_Box_Expanded>();

            init_Invisible(); //set page 2 as invisible

            List_Box_Pop(); //populate the recipe list results 

            ingredients_Grid_Pop(); //populate the ingredients grid

            check_Box_Array.First().Content = "poosd";

        }

        /**
         * boolean_Array is a class for storing a List of bool_IDs
         * 
         * Future plans are to have search and update functions 
         * */
        public class boolean_Array
        {
            List<bool_ID> list;
            
            public boolean_Array()
            {
                list = new List<bool_ID>();
            }
        }

        /**
         * bool_ID is a class for storing a boolean value and an ID integer associated with it.
         * 
         * */
        public class bool_ID
        {
            int id;
            Boolean flag;

            public bool_ID(int b_id)
            {
                id = b_id;
                flag = false;
            }
        }

        /**
         * List_Box_Pop is a poc function to explore populating a GUI object
         * such as RecipeViewer, which will display the recipe's our users 
         * click on.
         * 
         * It generates a random number and creates that many ListBoxItem objects.
         * then it fills the ListBoxItem objects with (currently useless) information
         * and adds each box to RecipeList
         * */
        private void List_Box_Pop()
        {
            RecipeViewer.Content = "iCount";

            Random number = new Random();

            int num = number.Next(20);

            List<ListBoxItem> items = new List<ListBoxItem>();

            for (int i = 0; i < num; i++)
            {
                ListBoxItem temp = new ListBoxItem();

                if (i == 1) temp.Content = "1 Bat";

                else temp.Content = i + " Bats";

                RecipeList.Items.Add(temp);

            }

            //int children = SearchPage.Children.Count;

        }

        /**
         * ingredients_Grid_Pop is another poc function to explore populating GUI 
         * containers. 
         * 
         * It creates a number (40 currently) of Expander objects and, in each, places a UniformGrid object.
         * The Expander is given a title(visible text in GUI) by setting its Header attribute. 
         * 
         * It adds 10 CheckBox objects to each UniformGrid as they are created. Visible text is assigned to
         * CheckBoxes by setting their Content attribute. 
         * 
         * Events are assigned actions, such as in:
         * 
         *      temp_Expander.Expanded += temp_Expander_Expanded;
         *      temp_Expander.Collapsed += temp_Expander_Collapsed;
         * 
         * Expanded and Collapsed are events, temp_Expander_(Expanded/Collapsed) are functions called when
         * the events they are added to occur. 
         * */
        private void ingredients_Grid_Pop()
        {
            Random number = new Random();
            int num = number.Next(20);

            for (int j = 0; j < 20; j++)
            {
                Expander temp_Expander = new Expander();
                UniformGrid temp_Grid = new UniformGrid();

                temp_Grid.Columns = 1;
                temp_Grid.Width = 500;

                temp_Expander.Header = "Subgroup " + j;
                
                for (int i = 0; i < 10  /*num*/; i++)
                {
                    check_Box_Expanded temp = new check_Box_Expanded("Cheese", i+(j*10)); //WARNING: This logic will break after categories expand beyond 10 items
                    //temp.Content = "Jalepeno Peppers" + i;                                //TODO: Find a better solution!
                    //ingredients_Sub_Grid.Children.Add(temp);
                    temp.Checked += check_Box_Checked_Event;
                    temp.Unchecked += check_Box_Unchecked_Event;
                    temp_Grid.Children.Add(temp);
                    check_Box_Array.Add(temp);                    //DISCOVERY!: modifying objects in a list will modify the same object in a container
                    
                    temp_Grid.Height += 15;
                    temp_Expander.Height += 15;
                }

                temp_Expander.Expanded += temp_Expander_Expanded;
                temp_Expander.Collapsed += temp_Expander_Collapsed;

                temp_Expander.Content = temp_Grid;

                ingredients_Sub_Grid.Children.Add(temp_Expander);
                
                ingredients_Sub_Grid.Height += 80;

            }
        }

        /**
         * check_Box_Expanded is a slight modification on the CheckBox class to include a Uid
         * */
        public class check_Box_Expanded : CheckBox
        {
            public check_Box_Expanded(String ingredient_Name, int id)
            {   
                this.Content = ingredient_Name;
                Uid = id.ToString();
            }
        }
                
        /**
         * check_Box_Checked_Event is the event handler for when an ingredient checkbox is checked
         * it can be used to update a boolean array (or anything else we may need to happen)
         * */
        void check_Box_Checked_Event(object sender, RoutedEventArgs e)
        {
            check_Box_Expanded temp = (check_Box_Expanded)e.Source;

            bool? b = temp.IsChecked;
            string tempStr = temp.Uid;

            //LABELFORLABELS.Content = b;
            LABELFORLABELS.Content = tempStr;
        }

        /**
         * check_Box_Unchecked_Event is the event handler for when an ingredient checkbox is unchecked
         * it can be used to update a boolean array (or anything else we may need to happen)
         * */
        void check_Box_Unchecked_Event(object sender, RoutedEventArgs e)
        {
            check_Box_Expanded temp = (check_Box_Expanded)e.Source;
            bool? b = temp.IsChecked;

            LABELFORLABELS.Content = b;
        }

        //event handler to decrease the size of the ingredients_Sub_Grid when an expander is clicked
        void temp_Expander_Collapsed(object sender, RoutedEventArgs e)
        {
            ingredients_Sub_Grid.Height -= 80;
        }

        //event handler to increase the size of the ingredients_Sub_Grid when an expander is clicked
        void temp_Expander_Expanded(object sender, RoutedEventArgs e)
        {
            ingredients_Sub_Grid.Height += 80;
        }

        //initializes the resultspage as invisible
        private void init_Invisible()
        {
            ResultsPage.Visibility = System.Windows.Visibility.Hidden;
        }

        /**
         * Search and Go_Back button events are handled here. They just cause the visibilies
         * of the two panels to swap
         * */
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            SearchPage.Visibility = ResultsPage.Visibility;
            ResultsPage.Visibility = System.Windows.Visibility.Visible;
        }

        private void Go_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            SearchPage.Visibility = ResultsPage.Visibility;
            ResultsPage.Visibility = System.Windows.Visibility.Hidden;
        }

        /**
         * RecipeList_SelectionChanged is the event handler for a user clicking on a recipe on
         * the sidebar of the results page. It sets the content of RecipeViewer.
         * */
        private void RecipeList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem temp = (ListBoxItem)RecipeList.SelectedItem;
            RecipeViewer.Content = temp.Content;
        }

        /**
         * These three guys down here handle events when certain modes are selected
         * Currently, they only ensure that one mode is selected at a time
         * */
        private void chef_Mode_Click(object sender, RoutedEventArgs e)
        {
            quick_And_Easy.IsChecked = false;
            intermediate.IsChecked = false;
        }

        private void intermediate_Click(object sender, RoutedEventArgs e)
        {
            quick_And_Easy.IsChecked = false;
            chef_Mode.IsChecked = false;
        }

        private void quick_And_Easy_Click(object sender, RoutedEventArgs e)
        {
            intermediate.IsChecked = false;
            chef_Mode.IsChecked = false;
        }
    }
}

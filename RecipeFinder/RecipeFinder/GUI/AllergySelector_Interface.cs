using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        /**
         * \fn    public void populateAllergies()
         * \brief Used to add allergies to the GUI.
         **/
        public void populateAllergies()
        {
            for(int i = 1; i < _allergyList.Capacity; i++)
            {
                IngredientCheckBox c = new IngredientCheckBox(i, i);
                c.Content = _allergyList[i].getName();

                c.Checked   += check_Box_Checked_Event;
                c.Unchecked += check_Box_Unchecked_Event;

                this.Allergies.Children.Add(c);
            }
        }
    }
}
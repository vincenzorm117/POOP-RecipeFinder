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
    partial class MainWindow : Window
    {
        /**
         * \fn    private void updateRecipeSelection(object sender, SelectionChangedEventArgs e)
         * \brief Used to update the viewer to show the users selection.
         * \param sender
         * \param e
         **/
        private void updateRecipeSelection(object sender, SelectionChangedEventArgs e)
        {
            ListBox s = (ListBox)e.Source;

            if(s != null && s.Items.Count > 0)
            {
                String x = s.SelectedItem.ToString();
                DisplayTitle.Text = x;

                Recipe r = (Recipe)_selections[x];

                DisplayTime.Text = String.Format("Total Time: {0}  Preparation Time: {1}", r.getTotalTime(), r.getPrepTime());

                StringBuilder displayedIngredients = new StringBuilder();

                foreach(Recipe.ingredientData d in r.getIngredients())
                {
                    displayedIngredients.Append(String.Format("{0} {1} {2}\n", d._amount, getTextMeasurement(d._measurement), _CategoryLists[d._categoryID][d._categoryIndex].getName()));
                }

                DisplayIngredients.Text = displayedIngredients.ToString();

                DisplayServings.Text = String.Format("{0}", r.getServings());
                DisplayCalories.Text = String.Format("{0} (kcal)", r.getCalories());
                DisplayFat.Text = String.Format("{0} (g)", r.getFat());
                DisplayCholeterol.Text = String.Format("{0} (mg)", r.getCholestoral());
                DisplaySodium.Text = String.Format("{0} (g)", r.getSodium());
                DisplayCarbs.Text = String.Format("{0} (g)", r.getCarbs());
                DisplayFiber.Text = String.Format("{0} (g)", r.getFiber());
                DisplayProtein.Text = String.Format("{0} (g)", r.getProtein());

                DispLayInstructions.Text = r.getInstructions();

            }
        }
    }
}
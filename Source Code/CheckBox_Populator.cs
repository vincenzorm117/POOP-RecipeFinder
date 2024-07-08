using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Collections.Generic;
using System;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        /**
         * \fn    public void populateFilterExpandersAndCheckBoxes()
         * \brief Used for creating the expanders and their check boxes
         **/
        public void populateFilterExpandersAndCheckBoxes()
        {
            //First for loop creates the expanders with its corresponding UniformGrid
            for(int i = 1; i < Enum.GetNames(typeof(IngredientCategory)).Length; i++)
            {
                //Expanders are the collapsable panel
                Expander e = new Expander();
                e.Header = Enum.GetName(typeof(IngredientCategory), i);

                //Takes into account when the enum value of "NONE" is reached
                if (e.Header.ToString().Equals("NONE"))
                    e.Header = "OTHER";

                //Create a uniform grid to hold all of the ingredients inside of the expander
                //Sets the number of columns to 3
                UniformGrid g = new UniformGrid();
                g.Columns = 3;

                for(int j = 1; j < _CategoryLists[i].ToArray().Length; j++)
                {
                    //Create a new ingredient check box for an ingredient and set it's various values
                    IngredientCheckBox c = new IngredientCheckBox(i, j);

                    c.Content = _CategoryLists[i][j].getName();

                    //Adds the action listeners to the check boxes for when the user selects the ingredient
                    c.Checked   += ingredient_Checked;
                    c.Unchecked += ingredient_Checked;

                    //Checkbox is added to the UniformGrid so it can be inside the expander
                    g.Children.Add(c);

                }

                //Sets the expanders shown content to be the newly created uniform grid and adds the expander to the UI
                e.Content = g;
                SearchFilters.Children.Add(e);
            }
        }

        /**
         * \fn    public void populateAllergies()
         * \brief Used to add allergies to the GUI.
         **/
        public void populateAllergies()
        {
            for(int i = 1; i < _allergyList.Capacity; i++)
            {
                AllergyCheckBox c = new AllergyCheckBox(i);
                c.Content = _allergyList[i].getName();

                c.Checked += allergy_Checked;
                c.Unchecked += allergy_Checked;

                this.Allergies.Children.Add(c);
            }
        }
    }
}
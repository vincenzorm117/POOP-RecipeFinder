﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Collections.Generic;
using System;

namespace RecipeFinder
{
    public class IngredientCheckBox : CheckBox
    {
        private int column;
        private int row;

        public void OurCheckBox()
        {
            new CheckBox();
        }

        public void setColumn(int c)
        { column = c; }

        public void setRow(int r)
        { row = r; }

        public int getColumn()
        { return column; }

        public int getRow()
        { return row; }
    }

    public partial class MainWindow : Window
    {
        /**
         * \fn    public void populateFilterExpandersAndCheckBoxes()
         * \brief Used for creating the expanders and their check boxes
         **/
        public void populateFilterExpandersAndCheckBoxes()
        {
            //First for loop creates the expanders with its corresponding UniformGrid
            for(int i = 0; i < Enum.GetNames(typeof(IngredientCategory)).Length; i++)
            {
                //Expanders are the collapsable panel
                Expander e = new Expander();
                e.Header = Enum.GetName(typeof(IngredientCategory), i);
                if (e.Header.ToString().Equals("NONE"))
                {
                    e.Header = "OTHER";
                }
                //Expanders have content but cannot store elements directly; it needs a grid to hold items
                //UniformGrid is the Expanders items container; what is unique about this grid is that it can columns and rows
                UniformGrid g = new UniformGrid();
                g.Columns = 2;  // The number of columns are set to 2 so it has 2 columns of checkboxes

                for(int j = 0; j < _CategoryLists[i].ToArray().Length; j++)
                {
                    IngredientCheckBox c = new IngredientCheckBox();            //CheckBox created
                    c.Content = _CategoryLists[i][j].getName(); //Its name is set
                    c.setColumn(i);
                    c.setRow(j);

                    //Adds actionlistener below (check_Box_Checked_Event) to current checkbox. So when the checkbox is selected that method is ran
                    c.Checked += check_Box_Checked_Event;
                    c.Unchecked += check_Box_Unchecked_Event;

                    //Checkbox is added to the UniformGrid so it can be inside the expander
                    g.Children.Add(c);

                }

                //The Expanders content is specified to be the current grid; comment out this line and see what happens
                e.Content = g;
                //The Current loops expander is added to the SearchFilters panel where they are placed in a stack manner because the panel is a StackPanel
                SearchFilters.Children.Add(e);
            }
        }
    }
}
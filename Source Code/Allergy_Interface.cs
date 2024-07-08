using System;
using System.Windows;
using System.Collections.Generic;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        /**
         * \fn     public static int getAllergySize()
         * \brief  Function for getting the number of allergies input from the allergy data file
         * \author Brian McCormick
         * \return The number of allergies currently loaded
         **/
        public static int getAllergySize()
        { return _allergyList.ToArray().Length; }

        /**
         * \fn           public static int getIngredientAllergy(int i, int j)
         * \brief        Function for getting the allergy value of a specific ingredient.
         * \author       Brian McCormick
         * \param [in] i The category index for the ingredient being selected.
         * \param [in] j The index value of the ingredient being selected within the ingredient category.
         * \return       The allergy value for the selected ingredient.
         **/
        public static int getIngredientAllergy(int i, int j)
        { return _CategoryLists[i][j].getAllergy(); }
    }
}
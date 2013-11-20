using System;
using System.Collections.Generic;
using System.Windows;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        private List<List<Ingredient>> _CategoryLists; ///< 2D List that holds the categorized ingredient lists

        /**
         * \fn     public void IngredientSplit()
         * \brief  Function for splitting the ingredients into separate category list.
         * \author Brian McCormick
         **/
        public void IngredientSplit()
        {
            //Variables used for controlling the splitting process
            IngredientCategory c = IngredientCategory.NONE;

            //Create a new 2D list of ingredients
            _CategoryLists = new List<List<Ingredient>>();
            for(int i = 0; i < Enum.GetValues( typeof(IngredientCategory) ).Length; i++)
                _CategoryLists.Add(new List<Ingredient>());

            //Loop through each ingredient that was pulled in from file
            foreach(Ingredient i in _ingredientList)
            {
                
            }
        }
    }
}
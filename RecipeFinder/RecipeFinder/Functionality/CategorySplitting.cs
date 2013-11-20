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
         * \todo   Add unit testing for this function.
         **/
        public void IngredientSplit()
        {
            //Variables used for controlling the splitting process
            IngredientCategory c = IngredientCategory.NONE;
            IngredientCategory t = IngredientCategory.NONE;

            //Create a new 2D list of ingredients
            _CategoryLists = new List<List<Ingredient>>();
            for(int i = 0; i < Enum.GetValues( typeof(IngredientCategory) ).Length; i++)
                _CategoryLists.Add(new List<Ingredient>());

            //Loop through each category
            for(int i = 0; i < Enum.GetValues(typeof(IngredientCategory)).Length; i++)
            {
                //Get the enumerated value for the current runthrough
                t = getCategory(i);

                //Loop through each ingredient that was pulled in from file
                foreach(Ingredient d in _ingredientList)
                {
                    //Get the enumerated ingredient category for the current ingredient
                    c = d.getCategory();

                    //Test if the current ingredient is to be placed into the category
                    if(c == t)
                    {   
                        //Set the category id of the ingredient
                        d.setCategoryID(_CategoryLists[i].Capacity);

                        //Adds a new ingredient to the proper category list
                        _CategoryLists[i].Add(new Ingredient(d));
                    }
                }

                //Remove excess memory
                _CategoryLists[i].TrimExcess();
            }
        }
    }
}
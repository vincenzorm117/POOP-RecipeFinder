using System;
using System.Collections.Generic;
using System.Windows;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        private List<List<Ingredient>> _CategoryLists;     ///< 2D List that holds the categorized ingredient lists
        public  List<List<Ingredient>> _TestCategoryLists; ///< 2D List that holds categorized ingredients for testing

        private List<List<bool>>       _CategoryBooleans;  ///< 2D List for holding user selections

        /**
         * \fn     public void IngredientSplit()
         * \brief  Function for splitting the ingredients into separate category list.
         * \author Brian McCormick
         * \todo   Add unit testing for this function.
         *         Only the unit test function is needed, there is a test list already set up to be created in this function.
         *         The test input file needs to be updated to give better test cases for this function.
         **/
        public void IngredientSplit()
        {
            //Variables used for controlling the splitting process
            IngredientCategory c = IngredientCategory.NONE;
            IngredientCategory t = IngredientCategory.NONE;

            //Create a new 2D list of ingredients
            _CategoryLists     = new List<List<Ingredient>>();
            _TestCategoryLists = new List<List<Ingredient>>();
            _CategoryBooleans  = new List<List<bool>>();
            for(int i = 0; i < Enum.GetValues( typeof(IngredientCategory) ).Length; i++)
            {
                _CategoryLists.Add(new List<Ingredient>());
                _TestCategoryLists.Add(new List<Ingredient>());
                _CategoryBooleans.Add(new List<bool>());
            }

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
                        _TestCategoryLists[i].Add(new Ingredient(d));
                        _CategoryBooleans[i].Add(false);
                    }
                }

                //Remove excess memory
                _CategoryLists[i].TrimExcess();
                _TestCategoryLists[i].TrimExcess();
                _CategoryBooleans[i].TrimExcess();
            }

            //Remove excess memory
            _CategoryLists.TrimExcess();
            _TestCategoryLists.TrimExcess();
            _CategoryBooleans.TrimExcess();
        }
    }
}
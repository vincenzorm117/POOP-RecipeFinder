using System;
using System.Collections.Generic;
using System.Windows;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        private static List<List<Ingredient>> _CategoryLists;     ///< 2D List that holds the categorized ingredient lists
        public  static List<List<Ingredient>> _TestCategoryLists; ///< 2D List that holds categorized ingredients for testing

        private static List<List<bool>>       _UserSelections;    ///< 2D List for holding user selections

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
            _UserSelections    = new List<List<bool>>();
            for(int i = 0; i < Enum.GetValues( typeof(IngredientCategory) ).Length; i++)
            {
                //Create a new list for each category
                _CategoryLists.Add(new List<Ingredient>());
                _TestCategoryLists.Add(new List<Ingredient>());
                _UserSelections.Add(new List<bool>());

                //Place buffers in each list
                _CategoryLists[i].Add(new Ingredient());
                _TestCategoryLists[i].Add(new Ingredient());
                _UserSelections[i].Add(false);
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
                        _UserSelections[i].Add(false);
                    }
                }

                //Remove excess memory
                _CategoryLists[i].TrimExcess();
                _TestCategoryLists[i].TrimExcess();
                _UserSelections[i].TrimExcess();
            }

            //Remove excess memory
            _CategoryLists.TrimExcess();
            _TestCategoryLists.TrimExcess();
            _UserSelections.TrimExcess();
        }

        /**
         * \fn     public List<List<bool>> GetCategoryBoolList()
         * \brief  Used for getting a new 2D boolean list of the same size as the split ingredient list.
         * \author Brian McCormick
         * \return A new 2D boolean list thats the same size as the main boolean ingredient list.
         * \todo   Add unit testing for this function.
         **/
        public static List<List<bool>> GetCategoryBoolList()
        {
            List<List<bool>> temp;
            temp = new List<List<bool>>(_UserSelections.ToArray().Length);

            foreach(List<bool> l in _UserSelections)
                temp.Add(new List<bool>(l.ToArray().Length));

            for(int i = 0; i < temp.ToArray().Length; i++)
                for(int j = 0; j < temp[i].ToArray().Length; i++)
                    temp[i][j] = false;

            return temp;
        }
    }
}
using System.Collections.Generic;
using RecipeFinder;
using System;

namespace Unit_Test
{
    public partial class UnitTest_Main
    {
        //Enum values used for comparison testing
        private static IngredientCategory _testCetegoryEnum; ///< Enum value used in testing the Ingredient Category enum

        //Arrays for holding test results and total number of tests performed
        private static int[] _categoryEnumTestResults; ///< Array that's used for holding the results of the Ingredient Category enum testing

        /**
         * \fn     private static void IngredientCategory_Test()
         * \brief  Function used to test the functionality of the Ingredient Category Enum and associated code.
         * \author Brian McCormick
         **/
        private static void IngredientCategory_Test()
        {
            //Constructs a new _results list object
            _results = new List<bool>();

            //Values used to track the number of tests performed
            int numCategories = Enum.GetValues(typeof(IngredientCategory)).Length; //The total number of enumerated values to test

            for(int i = 0; i < numCategories; i++)
            {
                _testCetegoryEnum = MainWindow.getCategory(i);
                testCurrentCategory(i);
            }

            _testCetegoryEnum = MainWindow.getCategory(-1);
            testCurrentCategory(-1);

            _testCetegoryEnum = MainWindow.getCategory(9);
            testCurrentCategory(9);

            //Store the results for display later
            _categoryEnumTestResults = new int[2];
            _categoryEnumTestResults[0] = numCategories + 2;
            _categoryEnumTestResults[1] = passCount();
        }

        /**
         * \fn           private static void testCurrentCategory(int i)
         * \brief        Function used for testing a single IngredientCategory value.
         * \author       Brian McCormick
         * \param [in] i The value that was used to fetch the Ingredient Category value being tested.
         **/
        private static void testCurrentCategory(int i)
        {
            bool tempControl = true;

            switch(i)
            {
                case 0: if(_testCetegoryEnum != IngredientCategory.NONE) tempControl = false;
                    break;
                case 1: if(_testCetegoryEnum != IngredientCategory.VEGETABLES) tempControl = false;
                    break;
                case 2: if(_testCetegoryEnum != IngredientCategory.FRUITS) tempControl = false;
                    break;
                case 3: if(_testCetegoryEnum != IngredientCategory.DAIRY) tempControl = false;
                    break;
                case 4: if(_testCetegoryEnum != IngredientCategory.SEAFOOD) tempControl = false;
                    break;
                case 5: if(_testCetegoryEnum != IngredientCategory.MEAT) tempControl = false;
                    break;
                case 6: if(_testCetegoryEnum != IngredientCategory.CARBOHYDRATES) tempControl = false;
                    break;
                default: if(_testCetegoryEnum != IngredientCategory.NONE) tempControl = false;
                    break;
            }

            //Adds the result to the results array
            addToResults(tempControl);
        }
    }
}
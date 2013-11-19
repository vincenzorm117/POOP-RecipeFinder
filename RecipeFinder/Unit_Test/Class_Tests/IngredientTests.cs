using System.Collections.Generic;
using RecipeFinder;
using System;

namespace Unit_Test
{
    public partial class UnitTest_Main
    {
        //Objects used for testing the ingredient class
        private static Ingredient _testIngredient; ///< Used for holding a single ingredient object

        //Boolean arrays used for storing test results
        private static int[] _ingredientBasicResults; ///< Array used for holding the number of passed tests and the total number of tests for the basic test

        /**
         * \fn      private static void Ingredient_BasicTest()
         * \brief   Function for testing the basic functionality of the ingredient class
         * \author  Brian McCormick
         **/
        private static void Ingredient_BasicTest()
        {
            //Constructs a new _results list object
            _results = new List<bool>();

            //Sets up some test parameters
            int numIterations = 20;                                                  //The total number of iterations being performed for integer values within the class
            int numStrings    = 3;                                                   //The total number of string values being tested
            int numCategories = Enum.GetValues( typeof(IngredientCategory) ).Length; //The total number of enumerated values to test
            
            //The string values being used for the testing
            string singleChar = "T";
            string singleWord = "Test";
            string multiWord  = "Testing the ingredient class";

            //Variable used for holding an enumerated value
            IngredientCategory c;

            //Calculate the total number of results
            int testOne       = 1;
            int testTwo       = (numIterations * numIterations * numCategories * numStrings);
            int testThree     = (numIterations * numIterations * numIterations * numCategories * numStrings);
            int numberResults = testOne + testTwo + testThree;


            //Perform the base constructor test
            _testIngredient = new Ingredient();
            testCurrentIngredient(-1, -1, -1, "", IngredientCategory.NONE);

            //Perform testing for the constructor with no allergy information
            for(int i = 0; i < numIterations; i++)
            {
                for(int j = 0; j < numIterations; j++)
                {
                    for(int k = 0; k < numCategories; k++)
                    {
                        //Get the enumerated value for this runthrough
                        c = MainWindow.getCategory(k);

                        _testIngredient = new Ingredient(i, singleChar, c);
                        _testIngredient.setCategoryID(j);
                        testCurrentIngredient(i, -1, j, singleChar, c);

                        _testIngredient = new Ingredient(i, singleWord, c);
                        _testIngredient.setCategoryID(j);
                        testCurrentIngredient(i, -1, j, singleWord, c);

                        _testIngredient = new Ingredient(i, multiWord, c);
                        _testIngredient.setCategoryID(j);
                        testCurrentIngredient(i, -1, j, multiWord, c);
                    }
                }
            }

            //Perform testing on the ingredient class with alergy information
            for(int i = 0; i < numIterations; i++)
            {
                for(int j = 0; j < numIterations; j++)
                {
                    for(int l = 0; l < numIterations; l++)
                    {
                        for(int k = 0; k < numCategories; k++)
                        {
                            //Get the enumerated value for this runthrough
                            c = MainWindow.getCategory(k);

                            _testIngredient = new Ingredient(i, l, singleChar, c);
                            _testIngredient.setCategoryID(j);
                            testCurrentIngredient(i, l, j, singleChar, c);

                            _testIngredient = new Ingredient(i, l, singleWord, c);
                            _testIngredient.setCategoryID(j);
                            testCurrentIngredient(i, l, j, singleWord, c);

                            _testIngredient = new Ingredient(i, l, multiWord, c);
                            _testIngredient.setCategoryID(j);
                            testCurrentIngredient(i, l, j, multiWord, c);
                        }
                    }
                }
            }

            //Store the results for display later
            _ingredientBasicResults = new int[2];
            _ingredientBasicResults[0] = numberResults;
            _ingredientBasicResults[1] = passCount();
        }

        /**
         * \fn             private static void testCurrentIngredient(int i, int a, int cid, string n, IngredientCategory c)
         * \brief          Function for testing an ingredient object against given values.
         * \author         Brian McCormick
         * \param [in] i   The value to test against the ingredient ID
         * \param [in] a   The value to test against the ingredient allergy value
         * \param [in] cid The value to test against the ingredient category id value
         * \param [in] n   The string value to test against the ingredient name
         * \param [in] c   The enumerated value to test against the ingredient category value
         **/
        private static void testCurrentIngredient(int i, int a, int cid, string n, IngredientCategory c)
        {
            bool tempControl = true;

            //Tests the three values of an ingredient class
            if(_testIngredient.getID() != i)
                tempControl = false;
            if(_testIngredient.getAllergy() != a)
                tempControl = false;
            if(_testIngredient.getName() != n)
                tempControl = false;
            if(_testIngredient.getCategoryID() != cid)
                tempControl = false;
            if(_testIngredient.getCategory() != c)
                tempControl = false;

            //Adds the result to the results array
            addToResults(tempControl);
        }
    }
}
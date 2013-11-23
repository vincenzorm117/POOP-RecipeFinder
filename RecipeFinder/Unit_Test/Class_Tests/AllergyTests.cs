using System.Collections.Generic;
using RecipeFinder;
using System;

namespace Unit_Test
{
    public partial class UnitTest_Main
    {

        /**
         * \fn      private static void Allergy_BasicTest()
         * \brief   Function for testing the basic functionality of the allergy class
         * \author Brian McCormick
         **/
        private static void Allergy_BasicTest()
        {
            //Constructs a new _results list object
            _results = new List<bool>();

            //Sets up some test parameters
            int iterations    = 5000;
            int numberTests   = 9;
            int numberResults = iterations * numberTests;

            //Set up string values for testing allergy name and message
            string singleChar = "T";
            string singleWord = "Test";
            string multiWord  = "Testing the allergy class";

            //Run through the constructor tests
            for(int i = 0; i < iterations; i++)
            {
                _testAllergy = new Allergy(i, singleChar, singleChar);
                testCurrentAllergy(i, singleChar, singleChar);
                
                _testAllergy = new Allergy(i, singleChar, singleWord);
                testCurrentAllergy(i, singleChar, singleWord);

                _testAllergy = new Allergy(i, singleChar, multiWord);
                testCurrentAllergy(i, singleChar, multiWord);

                _testAllergy = new Allergy(i, singleWord, singleChar);
                testCurrentAllergy(i, singleWord, singleChar);

                _testAllergy = new Allergy(i, singleWord, singleWord);
                testCurrentAllergy(i, singleWord, singleWord);

                _testAllergy = new Allergy(i, singleWord, multiWord);
                testCurrentAllergy(i, singleWord, multiWord);

                _testAllergy = new Allergy(i, multiWord, singleChar);
                testCurrentAllergy(i, multiWord, singleChar);

                _testAllergy = new Allergy(i, multiWord, singleWord);
                testCurrentAllergy(i, multiWord, singleWord);

                _testAllergy = new Allergy(i, multiWord, multiWord);
                testCurrentAllergy(i, multiWord, multiWord);
            }

            //Store the results for display later
            _allergyBasicResult = new int[2];
            _allergyBasicResult[0] = numberResults;
            _allergyBasicResult[1] = passCount();
        }

        /**
         * \fn     private static void Allergy_InputTest()
         * \brief  Function for testing reading in allergy from file.
         * \author Brian McCormick
         **/
        private static void Allergy_InputTest()
        {
            //Constructs a new _results list object
            _results = new List<bool>();

            //Sets up some test parameters
            int iterations    = 9;
            int numberTests   = 1;
            int numberResults = iterations * numberTests;

            //Set up string values for testing allergy name and message
            string singleChar = "T";
            string singleWord = "Test";
            string multiWord  = "Testing the input file code";

            //Used as variables to help swap out values for testing
            string n;
            string m;

            //Sets up the counter for tracking the iterations
            int i = 0;

            //Tries to fetch the data from file
            bool input = false;
            input = MainWindow.AllergyInput("../../Test_Input/Test_Allergy_Input.txt");

            //Stops the current test if the input file wasn't found
            if(!input)
            {
                _allergyInputResult = new int[2];
                _allergyInputResult[0] = numberResults;
                _allergyInputResult[1] = 0;
                return;
            }

            //Test the data read in from the file
            foreach(Allergy test in MainWindow._testAllergyList)
            {
                _testAllergy = test;
                
                if(i < 3)
                    n = singleChar;
                else if(i > 2 && i < 6)
                    n = singleWord;
                else
                    n = multiWord;

                if(i % 3 == 0)
                    m = singleChar;
                else if(i % 3 == 1)
                    m = singleWord;
                else
                    m = multiWord;

                testCurrentAllergy(i, n, m);
                i++;
            }

            //Store the results for display later
            _allergyInputResult = new int[2];
            _allergyInputResult[0] = numberResults;
            _allergyInputResult[1] = passCount();
        }

        /**
         * \fn      private static void testCurrentAllergy(int i, string n, string m, int o, int t)
         * \brief   Function used for testing a single allergy object.
         * \author  Brian McCormick
         * \param i The index value from the current iteration.
         * \param n The string value to test the allergy objects name value against.
         * \param m The string value to test the allergy objects message value against.
         **/
        private static void testCurrentAllergy(int i, string n, string m)
        {
            bool tempControl = true;

            //Tests the three values of an allergy object
            if(_testAllergy.getID() != i)
                tempControl = false;
            if(_testAllergy.getName() != n)
                tempControl = false;
            if(_testAllergy.getMsg() != m)
                tempControl = false;

            //Adds the result to the results array
            addToResults(tempControl);
        }
    }
}
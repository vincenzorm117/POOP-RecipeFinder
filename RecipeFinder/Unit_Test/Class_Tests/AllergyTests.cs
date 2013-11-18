using System.Collections.Generic;
using RecipeFinder;
using System;

namespace Unit_Test
{
    public partial class UnitTest_Main
    {
        //Variables used for testing the allergy class
        private static Allergy _testAllergy;        ///< Variable used for storing a single allergy object

        //Boolean array used for storing test results
        private static int[]   _allergyBasicResult; ///< Variable used for holding the number of passed tests and the total number of tests for the basic test
        private static int[]   _allergyInputResult; ///< Variable used for holding the number of passed tests and the total number of tests for the input file test

        /**
         * \fn     private static void Allergy_BasicTest()
         * \brief  Function for testing the basic functionality of the allergy class
         * \details This function runs through various scenarios for the allergy objects use of the constructor and getter functions.
         *          The ID is tested to hold up to the value 5000.
         *          The name is tested to hold single characters, single words, and multiple words.
         *          The message is tested to hold single characters, single words, and multiple words.
         *          With all combinations tested there are 45000 different combinations tested.
         * \author Brian McCormick
         **/
        private static void Allergy_BasicTest()
        {
            //Sets up some test parameters
            int iterations    = 5000;
            int numberTests   = 9;
            int numberResults = iterations * numberTests;

            //Sets up the memory needed for the results
            _results = new bool[numberResults];

            //Set up string values for testing allergy name and message
            string _singleChar = "T";
            string _singleWord = "Test";
            string _multiWord  = "Testing the allergy class";

            //Run through the constructor tests
            for(int i = 0; i < iterations; i++)
            {
                _testAllergy = new Allergy(i, _singleChar, _singleChar);
                testCurrentAllergy(i, _singleChar, _singleChar, 0, numberTests);
                
                _testAllergy = new Allergy(i, _singleChar, _singleWord);
                testCurrentAllergy(i, _singleChar, _singleWord, 1, numberTests);

                _testAllergy = new Allergy(i, _singleChar, _multiWord);
                testCurrentAllergy(i, _singleChar, _multiWord, 2, numberTests);

                _testAllergy = new Allergy(i, _singleWord, _singleChar);
                testCurrentAllergy(i, _singleWord, _singleChar, 3, numberTests);

                _testAllergy = new Allergy(i, _singleWord, _singleWord);
                testCurrentAllergy(i, _singleWord, _singleWord, 4, numberTests);

                _testAllergy = new Allergy(i, _singleWord, _multiWord);
                testCurrentAllergy(i, _singleWord, _multiWord, 5, numberTests);

                _testAllergy = new Allergy(i, _multiWord, _singleChar);
                testCurrentAllergy(i, _multiWord, _singleChar, 6, numberTests);

                _testAllergy = new Allergy(i, _multiWord, _singleWord);
                testCurrentAllergy(i, _multiWord, _singleWord, 7, numberTests);

                _testAllergy = new Allergy(i, _multiWord, _multiWord);
                testCurrentAllergy(i, _multiWord, _multiWord, 8, numberTests);
            }

            //Store the results for display later
            _allergyBasicResult = new int[2];
            _allergyBasicResult[0] = numberResults;
            _allergyBasicResult[1] = passCount(numberResults);
        }

        /**
         * \fn     private static void Allergy_InputTest()
         * \brief  Function for testing reading in allergy from file.
         * \author Brian McCormick
         **/
        private static void Allergy_InputTest()
        {
            //Sets up some test parameters
            int iterations    = 9;
            int numberTests   = 1;
            int numberResults = iterations * numberTests;

            //Set up string values for testing allergy name and message
            string _singleChar = "T";
            string _singleWord = "Test";
            string _multiWord  = "Testing the input file code";

            //Used as variables to help swap out values for testing
            string n;
            string m;

            //Sets up the memory needed for the results
            _results = new bool[numberResults];

            //Sets up the counter for tracking the iterations
            int  i     = 0;

            //Tries to fetch the data from file
            bool input = false;
            input = MainWindow.AllergyInput("../../Test_Input/Test_Allergy_Input.txt");

            //Test the data read in from the file
            foreach(Allergy test in MainWindow._testAllergyList)
            {
                _testAllergy = test;
                
                if(i < 3)
                    n = _singleChar;
                else if(i > 2 && i < 6)
                    n = _singleWord;
                else
                    n = _multiWord;

                if(i % 3 == 0)
                    m = _singleChar;
                else if(i % 3 == 1)
                    m = _singleWord;
                else
                    m = _multiWord;

                testCurrentAllergy(i, n, m, 0, numberTests);
                i++;
            }

            //Store the results for display later
            _allergyInputResult = new int[2];
            _allergyInputResult[0] = numberResults;
            _allergyInputResult[1] = passCount(numberResults);
        }

        /**
         * \fn      private static void testCurrentAllergy(int i, string n, string m, int o, int t)
         * \brief   Function used for testing a single allergy object.
         * \author  Brian McCormick
         * \param i The index value from the current iteration.
         * \param n The string value to test the allergy objects name value against.
         * \param m The string value to test the allergy objects message value against.
         * \param o The offset value used if there is more than one test performed in an iteration.
         * \param t The number of tests performed in an iteration.
         **/
        private static void testCurrentAllergy(int i, string n, string m, int o, int t)
        {
            bool _tempControl = true;

            //Tests the three values of an allergy object
            if(_testAllergy.getID() != i)
                _tempControl = false;
            if(_testAllergy.getName() != n)
                _tempControl = false;
            if(_testAllergy.getMsg() != m)
                _tempControl = false;

            //Adds the result to the results array
            addToResults(i, o, t, _tempControl);
        }
    }
}
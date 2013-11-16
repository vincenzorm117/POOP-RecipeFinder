using System.Collections.Generic;
using RecipeFinder;

namespace Unit_Test
{
    public partial class UnitTest_Main
    {
        //Variables used for testing the allergy class
        private static Allergy _testAllergy;        ///< Variable used for storing a single allergy object

        //Boolean array used for storing test results
        private static bool[]  _results;            ///< Variable used for storing all of the results for a particular test
        private static int[]   _allergyBasicResult; ///< Variable used for holding the number of failed tests and the total number of tests

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
            //Sets up the memory needed for the results
            _results       = new bool[45000];

            //Set up string values for testing allergy name and message
            string _singleChar = "T";
            string _singleWord = "Test";
            string _multiWord  = "Testing the allergy class";

            //Run through the constructor tests
            for(int i = 0; i < 5000; i++)
            {
                _testAllergy = new Allergy(i, _singleChar, _singleChar);
                testCurrentAllergy(i, _singleChar, _singleChar, 0, 9);
                
                _testAllergy = new Allergy(i, _singleChar, _singleWord);
                testCurrentAllergy(i, _singleChar, _singleWord, 1, 9);

                _testAllergy = new Allergy(i, _singleChar, _multiWord);
                testCurrentAllergy(i, _singleChar, _multiWord, 2, 9);

                _testAllergy = new Allergy(i, _singleWord, _singleChar);
                testCurrentAllergy(i, _singleWord, _singleChar, 3, 9);

                _testAllergy = new Allergy(i, _singleWord, _singleWord);
                testCurrentAllergy(i, _singleWord, _singleWord, 4, 9);

                _testAllergy = new Allergy(i, _singleWord, _multiWord);
                testCurrentAllergy(i, _singleWord, _multiWord, 5, 9);

                _testAllergy = new Allergy(i, _multiWord, _singleChar);
                testCurrentAllergy(i, _multiWord, _singleChar, 6, 9);

                _testAllergy = new Allergy(i, _multiWord, _singleWord);
                testCurrentAllergy(i, _multiWord, _singleWord, 7, 9);

                _testAllergy = new Allergy(i, _multiWord, _multiWord);
                testCurrentAllergy(i, _multiWord, _multiWord, 8, 9);
            }

            //Tally up the failed tests
            int _resultCounter = 0;
            for(int i = 0; i < 45000; i++)
                if(_results[i] == false)
                    _resultCounter++;

            //Store the results for display later
            _allergyBasicResult = new int[2];
            _allergyBasicResult[0] = 45000;
            _allergyBasicResult[1] = _resultCounter;
        }

        /**
         * \fn      private static void addToResults(int i, int o, bool r)
         * \brief   Function for storing a result to the results array.
         * \author  Brian McCormick
         * \param i The index value from the loop changing the values being tested.
         * \param o The offset used if there is more than one test performed in an iteration.
         * \param t The value of how many tests there are for each iteration.
         * \param r The boolean value resulting from testing an allergy object.
         **/
        private static void addToResults(int i, int o, int t, bool r)
        {
            _results[(i * t) + o] = r;
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
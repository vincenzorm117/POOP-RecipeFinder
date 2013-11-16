using System.Collections.Generic;
using RecipeFinder;

namespace Unit_Test
{
    public partial class UnitTest_Main
    {
        //Variables used for testing the allergy class
        private static Allergy _testAllergy;
        private static string  _singleChar;
        private static string  _singleWord;
        private static string  _multiWord;

        //Boolean array used for storing test results
        private static bool[]  _results;
        private static bool    _tempControl;
        private static int     _resultCounter;
        private static int[]   _allergyBasicResult;

        private static void Allergy_BasicTest()
        {
            //Sets up the memory needed for the results
            _results       = new bool[45000];
            _resultCounter = 0;

            //Set up string values for testing allergy name and message
            _singleChar = "T";
            _singleWord = "Test";
            _multiWord  = "Testing the allergy class";

            //Run through the constructor tests
            for(int i = 0; i < 5000; i++)
            {
                _testAllergy = new Allergy(i, _singleChar, _singleChar);
                testCurrentAllergy(i, _singleChar, _singleChar, 0);
                
                _testAllergy = new Allergy(i, _singleChar, _singleWord);
                testCurrentAllergy(i, _singleChar, _singleWord, 1);

                _testAllergy = new Allergy(i, _singleChar, _multiWord);
                testCurrentAllergy(i, _singleChar, _multiWord, 2);

                _testAllergy = new Allergy(i, _singleWord, _singleChar);
                testCurrentAllergy(i, _singleWord, _singleChar, 3);

                _testAllergy = new Allergy(i, _singleWord, _singleWord);
                testCurrentAllergy(i, _singleWord, _singleWord, 4);

                _testAllergy = new Allergy(i, _singleWord, _multiWord);
                testCurrentAllergy(i, _singleWord, _multiWord, 5);

                _testAllergy = new Allergy(i, _multiWord, _singleChar);
                testCurrentAllergy(i, _multiWord, _singleChar, 6);

                _testAllergy = new Allergy(i, _multiWord, _singleWord);
                testCurrentAllergy(i, _multiWord, _singleWord, 7);

                _testAllergy = new Allergy(i, _multiWord, _multiWord);
                testCurrentAllergy(i, _multiWord, _multiWord, 8);
            }

            for(int i = 0; i < 45000; i++)
                if(_results[i] == false)
                    _resultCounter++;

            _allergyBasicResult = new int[2];
            _allergyBasicResult[0] = 45000;
            _allergyBasicResult[1] = _resultCounter;
        }

        private static void addToResults(int i, int o, bool r)
        {
            _results[(i * 9) + o] = r;
        }

        private static void testCurrentAllergy(int i, string name, string message, int o)
        {
            _tempControl = true;

            if(_testAllergy.getID() != i)
                _tempControl = false;
            if(_testAllergy.getName() != name)
                _tempControl = false;
            if(_testAllergy.getMsg() != message)
                _tempControl = false;

            addToResults(i, o, _tempControl);
        }
    }
}
using System.Collections.Generic;
using RecipeFinder;
using System;

namespace Unit_Test
{
    public partial class UnitTest_Main
    {
        private static List<bool> _results; ///< List for holding a tests results

        /**
         * \fn                       private static int passCount()
         * \brief                    Function for tallying up the number of passed tests.
         * \author                   Brian McCormick
         * \return                   The number of passed tests.
         **/
        private static int passCount()
        {
            //Tally up the failed tests
            int _resultCounter = 0;

            //Loop through all of the collected results
            for(int i = 0; i < _results.ToArray().Length; i++)
                if(_results[i] == true)
                    _resultCounter++;

            return _resultCounter;
        }

        /**
         * \fn      private static void addToResults(bool r)
         * \brief   Function for storing a result to the results array.
         * \author  Brian McCormick
         **/
        private static void addToResults(bool r)
        {
            _results.Add(r);
        }
    }
}
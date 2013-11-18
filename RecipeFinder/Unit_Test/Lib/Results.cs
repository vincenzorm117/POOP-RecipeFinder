﻿using System.Collections.Generic;
using RecipeFinder;
using System;

namespace Unit_Test
{
    public partial class UnitTest_Main
    {
        private static bool[] _results; ///< Variable used for storing all of the results for a particular test

        /**
         * \fn                       private static int passCount(int numberResults)
         * \brief                    Function for tallying up the number of passed tests.
         * \author                   Brian McCormick
         * \param [in] numberResults The total number of results to iterate through.
         * \return                   The number of passed tests.
         **/
        private static int passCount(int numberResults)
        {
            //Tally up the failed tests
            int _resultCounter = 0;

            for(int i = 0; i < numberResults; i++)
                if(_results[i] == true)
                    _resultCounter++;

            return _resultCounter;
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
    }
}
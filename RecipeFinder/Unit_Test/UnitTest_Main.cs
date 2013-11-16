using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeFinder;

namespace Unit_Test
{
    /**
     * \class  UnitTest_Main
     * \brief  Main class holding all of the functionality for testing the RecipeFinder code.
     * \author Brian McCormick
     **/
    public partial class UnitTest_Main
    {
        /**
         * \fn     static void Main()
         * \brief  The main function used for running all of the unit tests.
         * \author Brian McCormick
         **/
        static void Main()
        {
            //Test the basic operations of the allergy class
            Console.Write("Testing Allergy Class...");
            Allergy_BasicTest();
            Console.WriteLine("{0} of {1} tests failed.", _allergyBasicResult[1], _allergyBasicResult[0]);

        }
    }
}
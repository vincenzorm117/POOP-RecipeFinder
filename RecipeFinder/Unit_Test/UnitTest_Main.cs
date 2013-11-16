using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeFinder;

namespace Unit_Test
{
    public partial class UnitTest_Main
    {
        static void Main(string[] args)
        {
            Console.Write("Testing Allergy Class...");
            Allergy_BasicTest();
            Console.WriteLine("{0} of {1} tests failed.", _allergyBasicResult[1], _allergyBasicResult[0]);

        }
    }
}
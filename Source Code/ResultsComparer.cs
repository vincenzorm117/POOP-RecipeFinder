using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder
{
    /**
     * \class  ResultsComparer
     * \brief  Used for comparing two recipeMatches structs together
     * \author Brian McCormick
     **/
    public class ResultsComparer : Comparer<recipeMatches>
    {
        /**
         * \fn           public override int Compare(recipeMatches x, recipeMatches y)
         * \brief        Function for comparing two recipeMatches structs.
         * \author       Brian McCormick
         * \param [in] x The first struct to use in the comparison.
         * \param [in] y The second struct to use in the comparison.
         * \return       The results of the comparison
         **/
        public override int Compare(recipeMatches x, recipeMatches y)
        {
            if(x.hitCounter.CompareTo(y.hitCounter) != 0)
                return x.hitCounter.CompareTo(y.hitCounter);
            else
                return x.recipeIndex.CompareTo(y.recipeIndex);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder
{
    /**
     * \class  Recipe
     * \brief  Storage for a single Recipe
     * \author Brian McCormick
     * \todo   Change the code for storing the ingredients
     **/
    class Recipe
    {
        private int     _TotalTime;                 ///< The total time for the recipe
        private int     _PrepTime;                  ///< The amount of time needed to prepare
        private int     _Servings;                  ///< How many servings the recipe makes
        private int     _Calories;                  ///< How many calories per serving (kcal)
        private int     _Fat;                       ///< How much fat per serving (g)
        private int     _Cholestorol;               ///< How much cholestorol per serving (mg)
        private int     _Sodium;                    ///< How much sodium per serving (mg)
        private int     _Carbs;                     ///< How many carb per serving (g)
        private int     _Fiber;                     ///< How much fiber per serving (g)
        private int     _Protein;                   ///< How much protien per serving (g)
        private int     _NumberOfIngredients;       ///< The total number of ingredients for this recipe

        //TODO: Replace this code with better storage code, probably use a smaller class with a vector system
        private int    *_IngredientAmountList;      ///< An array of the amounts needed for each ingredient
        private int    *_IngredientMeasurementList; ///< An array of the measurements to use for each ingredient
        private int    *_IngredientIDList;          ///< An array of each of the ingredients ID values

        private string  _Title;                     ///< The title of the recipe being stored
        private string  _Instructions;              ///< The instructions for the recipe being stored
    }
}

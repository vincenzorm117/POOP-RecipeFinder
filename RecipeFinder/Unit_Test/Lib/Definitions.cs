using System.Collections.Generic;
using RecipeFinder;
using System;

namespace Unit_Test
{
    public partial class UnitTest_Main
    {
        /************************/
        /* PRIVATE DECLARATIONS */
        /************************/

        private static List<bool> _results;               ///< List for holding a tests results
        private static Allergy    _testAllergy;           ///< Variable used for storing a single allergy object
        private static Ingredient _testIngredient;        ///< Used for holding a single ingredient object
        private static Ingredient _testIngredientTwo;     ///< Used for holding a single ingredient object
        private static Recipe     _testRecipe;            ///< Used for holding a single recipe object

        private static int[]     _allergyBasicResult;     ///< Array for holding the basic allergy test results
        private static int[]     _allergyInputResult;     ///< Array for holding the allergy input test results
        private static int[]     _ingredientBasicResults; ///< Array for holding the basic ingredient test results
        private static int[]     _ingredientInputResults; ///< Array for holding the ingredient input test results
        private static int[]     _recipeBasicResults;     ///< Array for holding the basic recipe test results
        private static int[]     _recipeInputResults;     ///< Array for holding the recipe input test results
    }
}
             
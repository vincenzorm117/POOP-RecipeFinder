using System;
using System.Windows;
using System.Collections.Generic;
using System.Collections;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        /******************************/
        /* PRIVATE VALUE DECLARATIONS */
        /******************************/

        private static List<Allergy>          _allergyList;     ///< The list used to hold the allergy list read in from file
        private static List<List<Ingredient>> _CategoryLists;   ///< 2D list that holds the categorized ingredient lists
        private static List<Ingredient>       _ingredientList;  ///< List for holding the ingredients read in from file
        private static List<List<bool>>       _UserSelections;  ///< 2D list for holding user selections
        private static List<int>              _CategoryCounter; ///< Tracks how many selections for a category there are
        private static List<bool>             _UsersAllergies;  ///< Boolean list of the users allergy selections
        private static List<Recipe>           _recipeList;      ///< The list used to hold the recipe list read in from file
        private static CookMode               _selectedMode;    ///< Variable used to hold the users cooking mode selection
        private static Hashtable              _selections;
        RecipeFinder.GUI.FoodSafetyModule     p;


        /*****************************/
        /* PUBLIC VALUE DECLARATIONS */
        /*****************************/
        public  static List<List<Ingredient>> _TestCategoryLists;  ///< 2D List that holds categorized ingredients for testing
        public  static List<Ingredient>       _testIngredientList; ///< List for holding read in ingredient data for testing
        public  static List<Allergy>          _testAllergyList;    ///< List for holding read in allergy data for testing
        public  static List<Recipe>           _testRecipeList;     ///< List for holding read in recipe data for testing
    }

    /***********************/
    /* STRUCT DECLARATIONS */
    /***********************/

    /**
     * \struct recipeMatches
     * \brief  Struct for holding a recipe index and the number of matching ingredients
     * \author Ronald Hyatt
     **/
    public struct recipeMatches
    {
        public int hitCounter;  ///< The number of ingredient matches for the recipe
        public int recipeIndex; ///< The recipe index value for the recipe matches being stored
    } 
}
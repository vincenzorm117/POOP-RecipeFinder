using System;
using System.Windows;
using System.Collections.Generic;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        /******************************/
        /* PRIVATE VALUE DECLARATIONS */
        /******************************/

        private static List<Allergy>          _allergyList;    ///< The list used to hold the allergy list read in from file
        private static List<List<Ingredient>> _CategoryLists;  ///< 2D list that holds the categorized ingredient lists
        private static List<Ingredient>       _ingredientList; ///< List for holding the ingredients read in from file
        private static List<List<bool>>       _UserSelections; ///< 2D list for holding user selections
        private static List<bool>             _UsersAllergies; ///< Boolean list of the users allergy selections
        private static List<Recipe>           _recipeList;     ///< The list used to hold the recipe list read in from file
        private static CookMode               _selectedMode;   ///< Variable used to hold the users cooking mode selection

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
     * \struct recipeIngredient
     * \brief  Struct used for temporarily holding a recipes ingredient data.
     * \author Brian McCormick
     **/
    public struct tempIngredientStorage
    {
        public string             quantity;      ///< Used to hold the ammount of the ingredient needed for the recipe.
        public int                measurementID; ///< Used to hold the stored ingredients unit of measurement.
        public int                ingredientID;  ///< Used to hold the ID value of the ingredient being stored.
        public IngredientCategory ingredientCat; ///< Used to hold the Category value of the ingredient being stored.
    }

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
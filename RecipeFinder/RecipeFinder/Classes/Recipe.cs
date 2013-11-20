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
    public class Recipe
    {
        /**
         * \struct ingredientData
         * \brief  Struct for holding ingredient data
         * \author Brian McCormick
         **/
        private struct ingredientData
        {
            int                _ammount;     ///< Holds the ammount of the ingredient as pulled in from file
            int                _categoryID;  ///< Holds the ID value for the ingredient as stored within it's associated category
            Measurements       _measurement; ///< Holds the measurement ID for the ingredient
            IngredientCategory _category;    ///< Holds the category that the ingredient is associated with
        }

        private int                  _TotalTime;           ///< The total time for the recipe
        private int                  _PrepTime;            ///< The amount of time needed to prepare
        private int                  _Servings;            ///< How many servings the recipe makes
        private int                  _Calories;            ///< How many calories per serving (kcal)
        private int                  _Fat;                 ///< How much fat per serving (g)
        private int                  _Cholestorol;         ///< How much cholestorol per serving (mg)
        private int                  _Sodium;              ///< How much sodium per serving (mg)
        private int                  _Carbs;               ///< How many carb per serving (g)
        private int                  _Fiber;               ///< How much fiber per serving (g)
        private int                  _Protein;             ///< How much protien per serving (g)
        private int                  _NumberOfIngredients; ///< The total number of ingredients for this recipe

        private string               _Title;               ///< The title of the recipe being stored
        private string               _Instructions;        ///< The instructions for the recipe being stored

        private List<ingredientData> _Ingredients;         ///< The list of ingredients for the recipe being stored

        private CookMode             _CookingMode;         ///< The difficulty of the recipe

        /**
         * \fn      public Recipe(int t, int p, int s, int c, int f, int h, int o, int a, int b, int r, int n, string i, string u, List<ingredientData> lst)
         * \brief   Class constructor used to create a recipe
         * \author  Ronald Hyatt
         * \param t The total time for the recipe.
         * \param p The preptime for the recipe.
         * \param s The servings for the recipe
         * \param c The calorie content for the recipe.
         * \param f The fat content for the recipe.
         * \param h The cholesterol content for the recipe.
         * \param o The sodium content for the recipe.
         * \param a The carbs content for the recipe.
         * \param b The fiber content for the recipe.
         * \param r The protein content for the recipe.
         * \param n The number of ingredients for the recipe.
         * \param i The title of the recipe.
         * \param u The instructions for the recipe.
         * \param m The mode for the recipe.
         **/
        public Recipe(int t, int p, int s, int c, int f, int h, int o, int a, int b, int r, int n, string i, string u, CookMode m)
        {
            _TotalTime           = t;
            _PrepTime            = p;
            _Servings            = s;
            _Calories            = c;
            _Fat                 = f;
            _Cholestorol         = h;
            _Sodium              = o;
            _Carbs               = a;
            _Fiber               = b;
            _Protein             = r;
            _NumberOfIngredients = n;
            _Title               = i;
            _Instructions        = u;
            _CookingMode         = m;
        }
    }
}

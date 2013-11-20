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
        
        private int                  _RecipeID;            ///< The ID number associated with the stored recipe
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
         * \fn      public Recipe(int d, int t, int p, int s, int c, int f, int h, int o, int a, int b, int r, int n, string i, string u, List<ingredientData> lst)
         * \brief   Class constructor used to create a recipe.
         * \author  Ronald Hyatt
         * \param [in] d The associated ID for the recipe.
         * \param [in] t The total time for the recipe.
         * \param [in] p The preptime for the recipe.
         * \param [in] s The servings for the recipe
         * \param [in] c The calorie content for the recipe.
         * \param [in] f The fat content for the recipe.
         * \param [in] h The cholesterol content for the recipe.
         * \param [in] o The sodium content for the recipe.
         * \param [in] a The carbs content for the recipe.
         * \param [in] b The fiber content for the recipe.
         * \param [in] r The protein content for the recipe.
         * \param [in] n The number of ingredients for the recipe.
         * \param [in] i The title of the recipe.
         * \param [in] u The instructions for the recipe.
         * \param [in] m The mode for the recipe.
         * \todo         Create a bool flag list systems for Ronnie.
         * \todo         When splitting ingredient lists keep track of sizes if possible of those lists.
         *               Alternate is setting up function to return the size of the selected list.
         **/
        public Recipe(int d, int t, int p, int s, int c, int f, int h, int o, int a, int b, int r, int n, string i, string u, CookMode m)
        {
            _RecipeID            = d; //Assigned based on a counter in the input function
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

        /**
         * 
         **/
        public int getRecipeID()
        { return _RecipeID;   }

        /**
         * 
         **/
        public CookMode getCookingMode()
        { return _CookingMode; }

        /**
         * 
         * \todo Fix to match allergy flag lists once complete.
         **/
        public bool getAllergy(int i)
        { return false;        }
    }
}

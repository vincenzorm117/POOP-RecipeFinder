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
            public string             _amount;      ///< Holds the ammount of the ingredient as pulled in from file
            public int                _categoryID;  ///< Holds the ID value for the ingredient as stored within it's associated category
            public Measurements       _measurement; ///< Holds the measurement ID for the ingredient
            public IngredientCategory _category;    ///< Holds the category that the ingredient is associated with
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
        
        private List<List<bool>>     _Temporary;           ///< Temporarily taking the place of the 2D bool array

        private CookMode             _CookingMode;         ///< The difficulty of the recipe

        /**
         * \fn              public Recipe(int id, int t, int p, int srv, int c, int f, int h, int o, int a, int b, int r, int n, string l, string u, CookMode m, List<recipeIngredient> list)
         * \brief           Class constructor used to create a recipe.
         * \author          Ronald Hyatt
         * \author          Brian McCormick
         * \param [in] id   The associated ID for the recipe.
         * \param [in] t    The total time for the recipe.
         * \param [in] p    The preptime for the recipe.
         * \param [in] srv  The servings for the recipe
         * \param [in] c    The calorie content for the recipe.
         * \param [in] f    The fat content for the recipe.
         * \param [in] h    The cholesterol content for the recipe.
         * \param [in] o    The sodium content for the recipe.
         * \param [in] a    The carbs content for the recipe.
         * \param [in] b    The fiber content for the recipe.
         * \param [in] r    The protein content for the recipe.
         * \param [in] n    The number of ingredients for the recipe.
         * \param [in] l    The title of the recipe.
         * \param [in] u    The instructions for the recipe.
         * \param [in] m    The mode for the recipe.
         * \param [in] list The list of ingredient data for the stored recipe.
         * \todo            Create a bool flag list systems for Ronnie.
         * \todo            When splitting ingredient lists keep track of sizes if possible of those lists.
         *                  Alternate is setting up function to return the size of the selected list.
         **/
        public Recipe(int id, int t, int p, int srv, int c, int f, int h, int o, int a, int b, int r, int n, string l, string u, List<tempIngredientStorage> list)
        {
            ingredientData temporaryStorage;

            _RecipeID            = id;  //Assigned based on a counter in the input function
            _TotalTime           = t;   //From file
            _PrepTime            = p;   //From file
            _Servings            = srv; //From file
            _Calories            = c;   //From file
            _Fat                 = f;   //From file
            _Cholestorol         = h;   //From file
            _Sodium              = o;   //From file
            _Carbs               = a;   //From file
            _Fiber               = b;   //From file
            _Protein             = r;   //From file
            _NumberOfIngredients = n;   //Either from file or counted during input, Will only represent total number of ingredients and not ingredient per category
            _Title               = l;   //From file
            _Instructions        = u;   //From file

            //Create the ingredients data list from raw data input
            _Ingredients = new List<ingredientData>();
            foreach(tempIngredientStorage temp in list)
            {
                temporaryStorage._amount      = temp.quantity;
                temporaryStorage._measurement = MainWindow.getMeasurement(temp.measurementID);
                temporaryStorage._category    = temp.ingredientCat;
                temporaryStorage._categoryID  = temp.ingredientID;

                _Ingredients.Add(temporaryStorage);
            }
            _Ingredients.TrimExcess();

            if(_TotalTime < 20)
            {}
            else if(_TotalTime <= 60)
            {}
            else
            {}

            //TEST CODE
            _Temporary = new List<List<bool>>();
        }

        /**
         * \fn      public int getRecipeID()
         * \brief   Function to grab the unique recipe ID.
         * \author  Brian McCormick
         **/
        public int getRecipeID()
        { return _RecipeID;   }

        /**
         * \fn      public CookMode getCookingMode()
         * \ brief  Function to grab the cooking mode the recipe is classified under
         * \author  Brian McCormick
         **/
        public CookMode getCookingMode()
        { return _CookingMode; }

        /**
         * \fn      public bool getAllergy(int i)
         * \brief   Functin to grab boolean value
         * \param   i The index of the allergy in the list.
         * \author  Brian McCormick
         * \todo Fix to match allergy flag lists once complete.
         **/
        public bool getAllergy(int i)
        { return false;        }

        /**
         * 
         **/
        public List<List<bool>> getIngredientFlags()
        { return _Temporary;   }
    }
}

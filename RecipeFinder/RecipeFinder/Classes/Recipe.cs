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
    public class Recipe : BaseClass
    {
        /**
         * \struct ingredientData
         * \brief  Struct for holding ingredient data
         * \author Brian McCormick
         **/
        private struct ingredientData
        {
            public string             _amount;        ///< Holds the ammount of the ingredient as pulled in from file
            public int                _categoryIndex; ///< Holds the index value within the category list for the ingredient
            public int                _categoryID;    ///< Holds the ID value for the ingredients category
            public Measurements       _measurement;   ///< Holds the measurement ID for the ingredient
            public IngredientCategory _category;      ///< Holds the category that the ingredient is associated with
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

        private string               _Instructions;        ///< The instructions for the recipe being stored

        private List<ingredientData> _Ingredients;         ///< The list of ingredients for the recipe being stored
        
        private List<List<bool>>     _BoolList;            ///< Used to represent if an ingredient is present or not
        private List<bool>           _AllergyBools;        ///< Used to represent if an allergy is present in the recipe

        private CookMode             _CookingMode;         ///< The difficulty of the recipe

        /**
         * \fn              public Recipe(int id, int t, int p, int srv, int c, int f, int h, int o, int a, int b, int r, int n, string l, string u, List<tempIngredientStorage> list) : base(id, l)
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
         * \param [in] list The list of ingredient data for the stored recipe.
         * \todo            Create a bool flag list systems for Ronnie.
         * \todo            When splitting ingredient lists keep track of sizes if possible of those lists.
         *                  Alternate is setting up function to return the size of the selected list.
         **/
        public Recipe(int id, int t, int p, int srv, int c, int f, int h, int o, int a, int b, int r, int n, string l, string u, List<tempIngredientStorage> list) : base(id, l)
        {
            ingredientData temporaryStorage;

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
            _NumberOfIngredients = n;   //Collect from the size of the list during input
            _Instructions        = u;   //From file

            //Create the ingredients data list from raw data input
            _Ingredients = new List<ingredientData>();
            foreach(tempIngredientStorage temp in list)
            {
                temporaryStorage._amount        = temp.quantity;
                temporaryStorage._measurement   = MainWindow.getMeasurement(temp.measurementID);
                temporaryStorage._category      = temp.ingredientCat;
                temporaryStorage._categoryIndex = temp.ingredientID;
                temporaryStorage._categoryID    = MainWindow.getCategoryIndex(temp.ingredientCat);

                _Ingredients.Add(temporaryStorage);
            }
            _Ingredients.TrimExcess();

            //Apply the cooking mode for the recipe
            if(_TotalTime < 20)
                _CookingMode = MainWindow.getCookMode(1);
            else if(_TotalTime <= 60)
                _CookingMode = MainWindow.getCookMode(2);
            else
                _CookingMode = MainWindow.getCookMode(3);

            //Set up 2D boolean array
            _BoolList     = MainWindow.GetCategoryBoolList();

            //Set up the allergy flag storage
            _AllergyBools = new List<bool>(MainWindow.getAllergySize());
            for(int i = 0; i < MainWindow.getAllergySize(); i++)
                _AllergyBools[i] = false;

            //Set a flag for which ingredients from the whole list of ingredients the recipe has
            foreach(ingredientData i in _Ingredients)
            {
                _BoolList[i._categoryID][i._categoryIndex] = true;

                if(_BoolList[i._categoryID][0] == false && _BoolList[i._categoryID][i._categoryIndex] == true)
                    _BoolList[i._categoryID][0] = true;

                if(MainWindow.getIngredientAllergy(i._categoryID, i._categoryIndex) > 0)
                {
                    _AllergyBools[0] = true;
                    _AllergyBools[MainWindow.getIngredientAllergy(i._categoryID, i._categoryIndex)] = true;
                }
            }
        }

        /**
         * \fn     public int getTotalTime()
         * \brief  Function for getting the recipes total cook time.
         * \author Brian McCormick
         **/
        public int getTotalTime()
        { return _TotalTime; }

        /**
         * \fn     public int getPrepTime()
         * \brief  Function for getting 
         * \author Brian McCormick
         **/
        public int getPrepTime()
        { return _PrepTime; }
        
        /**
         * \fn     public int getServings()
         * \brief  Function for getting the number of servings for the recipe.
         * \author Brian McCormick
         **/
        public int getServings()
        { return _Servings; }
        
        /**
         * \fn     public int getCalories()
         * \brief  Function for getting the recipes calories.
         * \author Brian McCormick
         **/
        public int getCalories()
        { return _Calories; }
        
        /**
         * \fn     public int getFat()
         * \brief  Function for getting the recipes fat ammount.
         * \author Brian McCormick
         **/
        public int getFat()
        { return _Fat; }

        /**
         * \fn     public int getCholestoral()
         * \brief  Function for getting the cholestoral value of the recipe.
         * \author Brian McCormick
         **/
        public int getCholestoral()
        { return _Cholestorol; }
        
        /**
         * \fn     public int getSodium()
         * \brief  Function for getting the sodium ammount for the recipe.
         * \author Brian McCormick
         **/
        public int getSodium()
        { return _Sodium; }
        
        /**
         * \fn     public int getCarbs()
         * \brief  Function for getting the ammount of carbs for the recipe.
         * \author Brian McCormick
         **/
        public int getCarbs()
        { return _Carbs; }
        
        /**
         * \fn     public int getFiber()
         * \brief  Function for getting the ammount of fiber in the recipe.
         * \author Brian McCormick
         **/
        public int getFiber()
        { return _Fiber; }
        
        /**
         * \fn     public int getProtein()
         * \brief  Function for getting the ammount of protein in the recipe.
         * \author Brian McCormick
         **/
        public int getProtein()
        { return _Protein; }
        
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
        { return _AllergyBools[i]; }

        /**
         * \fn     public List<List<bool>> getIngredientFlags()
         * \brief  Function for getting the 2D list representing present ingredients in the recipe.
         * \author Brian McCormick
         * \return The 2D list of booleans that represent which ingredients are present in the recipe.
         **/
        public List<List<bool>> getIngredientFlags()
        { return _BoolList; }
    }
}

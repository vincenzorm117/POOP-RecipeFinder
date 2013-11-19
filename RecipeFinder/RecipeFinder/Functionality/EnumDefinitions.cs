using System.Windows;

namespace RecipeFinder
{
    /**
     * \enum   IngredientCategory
     * \brief  Enum for ordering ingredient categories
     * \author Brian McCormick
     **/
    public enum IngredientCategory { NONE,          ///< NONE          = 0
                                     VEGITABLES,    ///< VEGITABLES    = 1
                                     FRUITS,        ///< FRUITS        = 2
                                     DAIRY,         ///< DAIRY         = 3
                                     SEAFOOD,       ///< SEAFOOD       = 4
                                     MEAT,          ///< MEAT          = 5
                                     CARBOHYDRATES  ///< CARBOHYDRATES = 6
                                   };

    /**
     * \enum   Measurements
     * \brief  Enum for ordering measurement id values
     * \author Brian McCormick
     **/
    public enum Measurements { NONE,       ///< NONE       = 0
                               TEASPOON,   ///< TEASPOON   = 1
                               TABLESPOON, ///< TABLESPOON = 2
                               CUP,        ///< CUP        = 3
                               HALFCUP     ///< HALFCUP    = 4
                             };

    /**
     * \enum   CookMode
     * \brief  Enum for ordering cooking mode types
     * \author Brian McCormick
     **/
    public enum CookMode { NONE,   ///< NONE   = 0
                           EASY,   ///< EASY   = 1
                           MIDDLE, ///< MIDDLE = 2
                           CHEF    ///< CHEF   = 3
                         };

    public partial class MainWindow : Window
    {
        /**
         * \fn           public static IngredientCategory getCategory(int i)
         * \brief        Function for getting an enumerated value for the ingredient category based on index value.
         * \author       Brian McCormick
         * \param [in] i The index value being located.
         * \return       The enumerated value at the given index value.
         *               Returns the NONE value if the index given doesn't exist.
         **/
        public static IngredientCategory getCategory(int i)
        {
            switch(i)
            {
                case 0: return IngredientCategory.NONE;
                case 1: return IngredientCategory.VEGITABLES;
                case 2: return IngredientCategory.FRUITS;
                case 3: return IngredientCategory.DAIRY;
                case 4: return IngredientCategory.SEAFOOD;
                case 5: return IngredientCategory.MEAT;
                case 6: return IngredientCategory.CARBOHYDRATES;
            }

            return IngredientCategory.NONE;
        }
    }
}
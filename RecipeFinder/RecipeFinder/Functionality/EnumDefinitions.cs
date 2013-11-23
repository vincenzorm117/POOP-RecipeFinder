using System.Windows;

namespace RecipeFinder
{
    /**
     * \enum   IngredientCategory
     * \brief  Enum for ordering ingredient categories
     * \author Brian McCormick
     **/
    public enum IngredientCategory { NONE,          ///< 0
                                     VEGITABLES,    ///< 1
                                     FRUITS,        ///< 2
                                     DAIRY,         ///< 3
                                     SEAFOOD,       ///< 4
                                     MEAT,          ///< 5
                                     CARBOHYDRATES, ///< 6
                                     POULTRY        ///< 7
                                   };

    /**
     * \enum   Measurements
     * \brief  Enum for ordering measurement id values
     * \author Brian McCormick
     **/
    public enum Measurements { NONE,       ///< 0
                               TEASPOON,   ///< 1
                               TABLESPOON, ///< 2
                               CUP,        ///< 3
                               CLOVES,     ///< 4
                               OUNCE,      ///< 5
                               POUND,      ///< 6
                               M_LITRE,    ///< 7
                               SLICES      ///< 8
                             };

    /**
     * \enum   CookMode
     * \brief  Enum for ordering cooking mode types
     * \author Brian McCormick
     **/
    public enum CookMode { NONE,         ///< 0
                           QUICKANDEASY, ///< 1
                           INTERMEDIATE, ///< 2
                           CHEF          ///< 3
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
                case 0:  return IngredientCategory.NONE;
                case 1:  return IngredientCategory.VEGITABLES;
                case 2:  return IngredientCategory.FRUITS;
                case 3:  return IngredientCategory.DAIRY;
                case 4:  return IngredientCategory.SEAFOOD;
                case 5:  return IngredientCategory.MEAT;
                case 6:  return IngredientCategory.CARBOHYDRATES;
                case 7:  return IngredientCategory.POULTRY;
                default: return IngredientCategory.NONE;
            }
        }

        /**
         * \fn           public static int getCategoryIndex(IngredientCategory c)
         * \brief        Function for getting the index value for an ingredient category enum value.
         * \author       Brian McCormick
         * \param [in] c The enum value to find the index value for.
         * \return       The index value for the enum value passed in.
         **/
        public static int getCategoryIndex(IngredientCategory c)
        {
            switch(c)
            {
                case IngredientCategory.NONE:          return 0;
                case IngredientCategory.VEGITABLES:    return 1;
                case IngredientCategory.FRUITS:        return 2;
                case IngredientCategory.DAIRY:         return 3;
                case IngredientCategory.SEAFOOD:       return 4;
                case IngredientCategory.MEAT:          return 5;
                case IngredientCategory.CARBOHYDRATES: return 6;
                case IngredientCategory.POULTRY:       return 7;
                default:                               return 0;
            }
        }

        /**
         * \fn           public static Measurements getMeasurement(int i)
         * \brief        Function for getting an enumerated value for the measurement category based on index value.
         * \author       Brian McCormick
         * \param [in] i The index value being located.
         * \return       The enumerated value at the given index value.
         *               Returns the NONE value if the index given doesn't exist.
         * \todo         Add a unit test for this function.
         **/
        public static Measurements getMeasurement(int i)
        {
            switch(i)
            {
                case 0:  return Measurements.NONE;
                case 1:  return Measurements.TEASPOON;
                case 2:  return Measurements.TABLESPOON;
                case 3:  return Measurements.CUP;
                case 4:  return Measurements.CLOVES;
                case 5:  return Measurements.OUNCE;
                case 6:  return Measurements.POUND;
                case 7:  return Measurements.M_LITRE;
                case 8:  return Measurements.SLICES;
                default: return Measurements.NONE;
            }
        }

        /**
         * \fn           public static CookMode getCookMode(int i)
         * \brief        Function for getting an enumerated value for the measurement category based on index value.
         * \author       Brian McCormick
         * \param [in] i The index value being located.
         * \return       The enumerated value at the given index.
         *               Returns the NONE value if the index given doesn't exist.
         * \todo         Add a unit test for this function.
         **/
        public static CookMode getCookMode(int i)
        {
            switch(i)
            {
                case 0:  return CookMode.NONE;
                case 1:  return CookMode.QUICKANDEASY;
                case 2:  return CookMode.INTERMEDIATE;
                case 3:  return CookMode.CHEF;
                default: return CookMode.NONE;
            }
        }
    }
}
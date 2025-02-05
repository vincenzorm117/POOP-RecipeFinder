﻿using System.Windows;
using System.Collections.Generic;
using System;

namespace RecipeFinder
{
    /**
     * \enum   IngredientCategory
     * \brief  Enum for ordering ingredient categories
     * \author Brian McCormick
     **/
    public enum IngredientCategory { NONE,          ///< Index: 0
                                     VEGETABLES,    ///< Index: 1
                                     FRUITS,        ///< Index: 2
                                     DAIRY,         ///< Index: 3
                                     SEAFOOD,       ///< Index: 4
                                     MEAT,          ///< Index: 5
                                     CARBOHYDRATES ///< Index: 6
                                   };

    /**
     * \enum   Measurements
     * \brief  Enum for ordering measurement id values
     * \author Brian McCormick
     **/
    public enum Measurements { NONE,       ///< Index: 0
                               TEASPOON,   ///< Index: 1
                               TABLESPOON, ///< Index: 2
                               CUP,        ///< Index: 3
                               CLOVES,     ///< Index: 4
                               OUNCE,      ///< Index: 5
                               POUND,      ///< Index: 6
                               M_LITRE,    ///< Index: 7
                               SLICES      ///< Index: 8
                             };

    /**
     * \enum   CookMode
     * \brief  Enum for ordering cooking mode types
     * \author Brian McCormick
     **/
    public enum CookMode { NONE,         ///< Index: 0
                           QUICKANDEASY, ///< Index: 1
                           INTERMEDIATE, ///< Index: 2
                           CHEF          ///< Index: 3
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
                case 1:  return IngredientCategory.VEGETABLES;
                case 2:  return IngredientCategory.FRUITS;
                case 3:  return IngredientCategory.DAIRY;
                case 4:  return IngredientCategory.SEAFOOD;
                case 5:  return IngredientCategory.MEAT;
                case 6:  return IngredientCategory.CARBOHYDRATES;
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
                case IngredientCategory.VEGETABLES:    return 1;
                case IngredientCategory.FRUITS:        return 2;
                case IngredientCategory.DAIRY:         return 3;
                case IngredientCategory.SEAFOOD:       return 4;
                case IngredientCategory.MEAT:          return 5;
                case IngredientCategory.CARBOHYDRATES: return 6;
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

        /**
         * \fn           public static bool compareCookMode(CookMode a, CookMode b)
         * \brief        Function for comparing two cooking mode values.
         * \author       Brian McCormick
         * \param [in] a One of the cooking mode values to compare.
         * \param [in] b One of the cooking mode values to compare.
         * \return       A boolean value of if the two values are the same or not.
         **/
        public static bool compareCookMode(CookMode a, CookMode b)
        {
            if(a == b)
                return true;
            else
                return false;
        }

        /**
         * \fn     public static int getSizeCategory()
         * \brief  Function for getting the size of the ingredient category enumerator.
         * \author Brian McCormick
         * \return The size of the ingredient category enum.
         **/
        public static int getSizeCategory()
        { return Enum.GetValues(typeof(IngredientCategory)).Length; }

        /**
         * \fn     public static int getSizeMode()
         * \brief  Function for getting the size of the cook mode enumerator.
         * \author Brian McCormick
         * \return The size of the cook mode enum.
         **/
        public static int getSizeMode()
        { return Enum.GetValues(typeof(CookMode)).Length; }

        /**
         * \fn           public static String getTextMeasurement(Measurements m)
         * \brief        Used to get a formatted string output for an enumerated value.
         * \author       Vincenzo Marconi
         * \param [in] m The enumerated value to map to a string.
         * \return       The formatted string value for the enumerator.
         **/
        public static String getTextMeasurement(Measurements m)
        {
            switch(m)
            {
                case Measurements.TEASPOON:   return "teaspoon(s)";
                case Measurements.TABLESPOON: return "tablespoon(s)";
                case Measurements.CUP:        return "cup(s)";
                case Measurements.CLOVES:     return "clove(s)";
                case Measurements.OUNCE:      return "ounce(s)";
                case Measurements.POUND:      return "pound(s)";
                case Measurements.M_LITRE:    return "M Litre(s)";
                case Measurements.SLICES:     return "slice(s)";
                default:                      return "";
            }
        }

    }
}
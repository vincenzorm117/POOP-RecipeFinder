using System;
using System.Windows;
using System.Collections.Generic;

namespace RecipeFinder
{

    public partial class MainWindow : Window
    {
        //Returns nothing for now
        //Based on discussion from 11/13/13
        //Input: take in the user's search parameters and the list of recipes.
        //          each recipe should have it's own 2d array of bools,
        //          an array of recipes,
        //          an integer representing the cooking mode,
        //          a bool array representing the different allergens
        //TODO: Update code documentation for entire file to match current documentation standard

        /**
             * \struct recipeIndex
             * \brief  Struct for holding the recipe and number of matching ingredients
             * \author Ronald Hyatt
             **/
        public struct recipeMatches
        {
            public int hitCounter;
            public int recipeIndex;
        }        


        /**
         * \fn         public List<Recipe> searchForRecipies(List<List<bool>> userSearchParams, CookMode cookingMode, List<bool> userAlergens)
         * \brief      Function for searching the recipes for users specifications
         * \author     Ronald Hyatt.
         * \param      userAllergens     The user allergens that they have selected
         * \return     A list of recipes that match the user's specifications
         **/
        public List<recipeMatches> searchForRecipies(List<bool> userAllergens)
        {

            //Create a new List for the results
            List<recipeMatches> results = new List<recipeMatches>();                ///< This is the list created to hold the results

            //Get the number of categories
            int numCategories = Enum.GetNames(typeof(IngredientCategory)).Length;   
            int numAllergens  = Enum.GetNames(typeof(Allergy)).Length;              
            int i, j, hits;
            bool skip;
            List<List<bool>> recipeIngredients;
            recipeMatches newRecipe = new recipeMatches();

            //Loop through each recipe
            foreach(Recipe current in _recipeList)
            
            {
                skip = false;
                hits = 0;
                recipeIngredients = current.getIngredientFlags();
                
                //If the cooking mode does not match the user's then move on
                if (!(selectedMode.Equals(current.getCookingMode())))
                {
                    continue;
                }

                else
                {
                    //If one of the alergy flags matches what the user is allergic to move on
                    for(i = 0; i < numAllergens; i ++)
                    {
                        //TODO make getter for recipe allergens
                        if(current.getAllergy(0) == false)
                            break;
                        else if (current.getAllergy(i) == userAllergens[i])
                        {
                            skip = true;
                            break;
                        }
                    }
                    //If there is an allergen that matches then skip the recipe
                    if (skip)
                    {
                        continue;
                    }

                    newRecipe = new recipeMatches();

                    //Compare categories
                    for (i = 0; i < numCategories; i++)
                    {
                        if ((_CategoryBooleans[i][0].Equals(true)) && (recipeIngredients[i][0].Equals(true)))
                        {
                            //Grab that number of ingrediants for this category
                            //TODO: grab the number of ingrediants from this specific category
                            //TODO: Redo when recipe has way of passing it's number of ingredients

                            //If the category is true then loop through the ingredients within
                            //TODO: Redo to actually compare
                            for (j = 0; j < recipeIngredients[i].ToArray().Length; j++)
                            {
                                if ((_CategoryBooleans[i][j].Equals(true)) && (recipeIngredients[i][j].Equals(true)))
                                {
                                    hits = hits + 1;
                                }

                            }
                        }
                    }
                    //If there is at least one hit add it to the list
                    if (hits >= 1)
                    {
                        newRecipe.recipeIndex = current.getRecipeID();
                        newRecipe.hitCounter = hits;
                        
                        results.Add(newRecipe);
                    }
                }

            }

            //TODO Sort the results from the search
            results.Sort();

            return results;
        }
    }
}

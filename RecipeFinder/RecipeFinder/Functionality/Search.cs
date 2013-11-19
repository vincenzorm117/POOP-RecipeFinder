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

        //Create struct for the recipes
        struct recipeMaches
        {
            int recipeIndex;
            int hitCounter;
        }

        public List<Recipe> searchForRecipies(List<List<bool>> userSearchParams, CookMode cookingMode, List<bool> userAlergens)
        {

            //Create a new List for the results
            List<Recipe> results = new List<Recipe>();

            //Get the number of categories
            int categories = Enum.GetNames(typeof(IngredientCategory)).Length;
            int ingredients;

            for(Recipe current in _recipeList){

            }





            return results;
        }
    }
}

/*
{   
            //Recipe needs to be some sort of accessable object
            //Struct to keep track of the correct hits each recipe gets based on the search
            struct recipeMatches 
            {
                int recipeIndex;
                int hitCounter;
            }


//            //Hard code in the number of catagories of ingrediants and the number per each
//            int categories  = Enum.GetNames( typeof(IngredientCategory) ).Length;

            //TODO: Rework ingredient ammount to be fetched from the lists for each category
            int ingrediants = Enum.GetNames( typeof(IngredientCategory) ).Length;

            //Grab each ingrediant list from each recipe
            List<List<bool>> recipeIngrediants = new List<List<bool>>();
            
            int k;

            //First use the filters to remove any that match (i.e. milk alergy skip that record
            //Loop throughout the list of recipes
            _recipeList = new List<Recipe>();
            for(Recipe current : _recipeList)
            {
                //Reset counter
                k = 0;

                //Check if the recipe has the alergen
                if (recipeList[i].alergen == true) 
                    continue;

                //Check to see if the recipe meets the correct 'mode'
                else if (recipeList[i].mode.containsEqualIgnoreCase(mode))
                {
                    //Grab the current recipe's list of ingredientes (again full list with true/false)
                    recipeIngredients = recipeList[i].ingrediantList;

                    //As we have flitered out hte recipes that we didn't want so we continue of filtering
                    for(int j = 0; j < categories; j++)
                    {
                        //Checing that both the user's and the recipie have the same category
                        if ((recipeIngredients[j][] == 1) && (userSeachParams[j][] == 1))
                            for (int s = 0; s < ingrediants; s++)
                            {
                                if ((recipeIngredients[j][s] == 1) && (userSeachParams[j][s] == 1))
                                    k = k + 1;
                            }
                    }

                    //Add the recipe to the results array setting the hit counter
                    recipeResults[i].recipe = recipeList[i].recipeId;
                    recipeResults[i].hitCounter = k;
                }
                //We have hit things we don't want so continue
                else
                    continue;
            }

            //Here we would order the results based on each recipe's hit counter
            Array.Sort(recipeResults);
            
            //Reverse the results as it is in ascending order
            Array.Reverse(recipeResults);

            //Grab the first 10
            Array.Copy(recipeResults, results, 10);

            //return the top 10
            return results;
        }
*/
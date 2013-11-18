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
        public Recipe[] searchForRecipies(bool[][] userSearchParams, CookMode cookingMode,  bool[] userAlergens)
        {   
            //Recipe needs to be some sort of accessable object
            //Struct to keep track of the correct hits each recipe gets based on the search
            struct recipeMatches 
            {
                int recipeIndex;
                int hitCounter;
            }

            //Hard code in the number of catagories of ingrediants and the number per each
            //TODO: Get length of array for number of categories
            //TODO: Rework ingredient ammount to be fetched from the lists for each category
            Array values    = Enum.GetValues( typeof(IngredientCategory) );
            int categories  = 8;
            int ingrediants = 12;

            //Create an array based on length of recipe list
            //TODO: See about maybe reworking as a List<recipeMatches> to skip allocation process
            recipeMatches[] recipeResults = new recipeMatches[_recipeList.ToArray().Length];

            //TODO: Rework just to hold all results
            //TODO: Use list to hold results
            Recipe[] results = new Recipe[10];

            //Grab each ingrediant list from each recipe
            bool[][] recipeIngrediants = new bool[categories][ingrediants];
            
            int k;

            //First use the filters to remove any that match (i.e. milk alergy skip that record
            //Loop throughout the list of recipes
            for(int i = 0; i < 100; i++)
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
    }
}
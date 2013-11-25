using System;
using System.Windows;
using System.Collections.Generic;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        /**
         * \fn                        public List<recipeMatches> searchForRecipies()
         * \brief                     Function for searching the recipes for users specifications
         * \author                    Ronald Hyatt
         * \return                    A list of recipes that match the user's specifications
         **/
        public List<recipeMatches> searchForRecipies()
        {
            //Declare variables for controlling the searching process
            int              hits      = 0;
            bool             skip      = false;
            recipeMatches    newRecipe = new recipeMatches();
            List<List<bool>> recipeIngredients;

            //Create a new List for the results
            List<recipeMatches> results = new List<recipeMatches>();

            //Get the number of categories
            int numCategories = Enum.GetNames(typeof(IngredientCategory)).Length;
            int numAllergens  = _allergyList.ToArray().Length;

            //Loop through each recipe
            foreach(Recipe current in _recipeList)
            {
                hits = 0;
                recipeIngredients = current.getIngredientFlags();
                
                //If the cooking mode does not match the user's and the cooking mode isn't "NONE" then move on
                if(!compareCookMode(_selectedMode, current.getCookingMode()) && 
                   !compareCookMode(_selectedMode, CookMode.NONE))
                    continue;
                else
                {
                    //If one of the alergy flags matches what the user is allergic to move on
                    if (current.getAllergy(0) && _UsersAllergies[0])
                    {
                        skip = false;

                        for(int i = 1; i < numAllergens; i ++)
                        {
                            if (current.getAllergy(i) && _UsersAllergies[i])
                            {
                                skip = true;
                                break;
                            }
                        }
                        if(skip)
                            continue;
                    }

                    newRecipe = new recipeMatches();

                    //Compare categories
                    for (int i = 0; i < numCategories; i++)
                    {
                        if(_UserSelections[i][0] && recipeIngredients[i][0])
                        {
                            //If the category is true then loop through the ingredients within
                            for (int j = 1; j < recipeIngredients[i].ToArray().Length; j++)
                            {
                                if(_UserSelections[i][j] && recipeIngredients[i][j])
                                {
                                    hits = hits + 1;
                                }

                            }
                        }
                    }
                    //If there is at least one hit add it to the list
                    if (hits >= 1)
                    {
                        newRecipe.recipeIndex = current.getID();
                        newRecipe.hitCounter = hits;
                        
                        results.Add(newRecipe);
                    }
                }

            }

            results.Sort(new ResultsComparer());
            return results;
        }
    }
}

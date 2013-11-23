using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        /**
         * \fn              public static bool AllergyInput(string path)
         * \brief           Function for reading allergy data in from file.
         * \author          Brian McCormick
         * \param [in] path The path to the input file.
         * \return          A boolean value representing if the process was successful or not.
         * \warning         If the path given is not either a hard-coded direct path or a path relative to where the executable is located
         *                  then the allergy input file will not be found.
         * \todo            Add a means of removing and/or ignoring duplicate ID values from the allergy input file.
         **/
        public static bool AllergyInput(string path)
        {
            //Variables used for controlling the input process
            int      counter  = 0;
            int      tempID   = 0;
            string   tempName = "";
            string[] lines;
            Allergy  tempAllergy;

            //Creates a new list of allergy objects
            _allergyList     = new List<Allergy>();
            _testAllergyList = new List<Allergy>();
            _UsersAllergies  = new List<bool>();

            //If the file at the target path exists then proceed with the input from file
            if(File.Exists(path))
            {
                //Read in all the lines from file
                lines = File.ReadAllLines(path);

                //Iterate through all the lines read in from the file
                foreach(string line in lines)
                {
                    //Test for unwanted lines from the input file: Empty Strings
                    if(line != "")
                    {
                        //Store the data based on the runthrough, on every third iteration create a new allergy object
                        if(counter == 0)
                            int.TryParse(line, out tempID);
                        else if(counter == 1)
                            tempName = line;
                        else if(counter == 2)
                        {
                            tempAllergy = new Allergy(tempID, tempName, line);
                            _allergyList.Add(tempAllergy);
                            _testAllergyList.Add(tempAllergy);
                            _UsersAllergies.Add(false);
                        }

                        //Reset the counter after each allergy object creation
                        counter++;
                        if(counter >= 3)
                            counter = 0;
                    }
                }

                //Clean up any extra space not needed
                _allergyList.TrimExcess();
                _testAllergyList.TrimExcess();

                //Return a success
                return true;
            }
            else
            {
                /**
                 * \todo Add implementation for adding the error on having a failed allergy input to a log file
                 **/
                Console.WriteLine("ERROR: Allergy File Not Found!");
                return false;
            }
        }

        /**
         * \fn              public static bool IngredientInput(string path)
         * \brief           Function for reading ingredient data in from file.
         * \author          Brian McCormick
         * \param [in] path The path to the input file.
         * \return          A boolean value representing if the process was successful or not.
         * \warning         If the path given is not either a hard-coded direct path or a path relative to where the executable is located
         *                  then the ingredient input file will not be found.
         * \todo            Add a means of removing and/or ignoring duplicate ID values from the ingredient input file.
         **/
        public static bool IngredientInput(string path)
        {
            //Declare variables used for controlling the input process
            IngredientCategory tempEnum     = IngredientCategory.NONE;
            int                counter      = 0;
            int                tempID       = 0;
            int                tempCategory = 0;
            int                tempAllergy  = 0;
            string             tempName     = "";
            string[]           lines;
            Ingredient         tempIngredient;
            

            //Create new lists to save input data to
            _ingredientList     = new List<Ingredient>();
            _testIngredientList = new List<Ingredient>();

            if(File.Exists(path))
            {
                //Read in all the lines from file
                lines = File.ReadAllLines(path);

                foreach(string line in lines)
                {
                    //Test for empty lines
                    if(line != "")
                    {
                        if(counter == 0)
                            int.TryParse(line, out tempID);
                        else if(counter == 1)
                            tempName = line;
                        else if(counter == 2)
                        {
                            int.TryParse(line, out tempCategory);
                            tempEnum = getCategory(tempCategory);
                        }
                        else if(counter == 3)
                        {
                            int.TryParse(line, out tempAllergy);

                            if(tempAllergy <= 0)
                                tempIngredient = new Ingredient(tempID, tempName, tempEnum);
                            else
                                tempIngredient = new Ingredient(tempID, tempAllergy, tempName, tempEnum);

                            _ingredientList.Add(tempIngredient);
                            _testIngredientList.Add(tempIngredient);
                        }

                        //Reset the counter after each ingredient object creation
                        counter++;
                        if(counter >= 4)
                            counter = 0;
                    }
                }

                //Clean up any extra space not needed
                _ingredientList.TrimExcess();
                _testIngredientList.TrimExcess();

                //Return a success message
                return true;
            }
            else
            {
                /**
                 * \todo Add implementation for adding the error on having a failed ingredient input to a log file
                 **/
                Console.WriteLine("ERROR: Ingredient File Not Found!");
                return false;
            }
        }

        /**
         * \fn              public static bool RecipeInput(string path)
         * \brief           Function for reading recipe data in from file.
         * \author          Brian McCormick
         * \param [in] path The path to the input file.
         * \return          A boolean value representing if the process was successful or not.
         * \warning         If the path given is not either a hard-coded direct path or a path relative to where the executable is located
         *                  then the ingredient input file will not be found.
         * \todo            Add a means of removing and/or ignoring duplicate ID values from the ingredient input file.
         **/
        public static bool RecipeInput(string path)
        {
            //Declare variables used in controlling the input process
            int                         counter        = 0;
            int                         counterTwo     = 0;
            int                         counterID      = 0;
            int                         tempTime       = 0;
            int                         tempPrep       = 0;
            int                         tempServings   = 0;
            int                         tempCalories   = 0;
            int                         tempFat        = 0;
            int                         tempChol       = 0;
            int                         tempSodium     = 0;
            int                         tempCarb       = 0;
            int                         tempFiber      = 0;
            int                         tempProtein    = 0;
            int                         tempNumIngrd   = 0;
            int                         tempMeasure    = 0;
            int                         tempID         = 0;
            List<tempIngredientStorage> tempIngredient = new List<tempIngredientStorage>();
            char[]                      delimiters     = { ' ' };
            string                      tempQuantity   = "";
            string                      tempName       = "";
            string                      tempInstr      = "";
            string[]                    lines;
            string[]                    parsedLine;
            tempIngredientStorage       stagedIngredient;

            //Checks if the input file exists
            if(File.Exists(path))
            {
                //Read in the entire file
                lines = File.ReadAllLines(path);

                //Reset the recipe ID counter
                counterID = 0;

                foreach(string l in lines)
                {
                    if(counter == 0)
                        tempName = l;
                    else if(counter == 1)
                        int.TryParse(l, out tempTime);
                    else if(counter == 2)
                        int.TryParse(l, out tempPrep);
                    else if(counter == 3)
                        int.TryParse(l, out tempServings);
                    else if(counter == 4)
                        int.TryParse(l, out tempCalories);
                    else if(counter == 5)
                        int.TryParse(l, out tempFat);
                    else if(counter == 6)
                        int.TryParse(l, out tempChol);
                    else if(counter == 7)
                        int.TryParse(l, out tempSodium);
                    else if(counter == 8)
                        int.TryParse(l, out tempCarb);
                    else if(counter == 9)
                        int.TryParse(l, out tempFiber);
                    else if(counter == 10)
                        int.TryParse(l, out tempProtein);
                    else if(counter == 11)
                    {
                        counterTwo = 0;
                        parsedLine = l.Split(delimiters);

                        foreach(string x in parsedLine)
                        {
                            if(counterTwo == 0)
                                tempQuantity = x;
                            else if(counterTwo == 1)
                                int.TryParse(x, out tempMeasure);
                            else if(counterTwo == 2)
                            {
                                int.TryParse(x, out tempID);

                                stagedIngredient.quantity      = tempQuantity;
                                stagedIngredient.measurementID = tempMeasure;
                                stagedIngredient.ingredientID  = _ingredientList[tempID].getCategoryID();
                                stagedIngredient.ingredientCat = _ingredientList[tempID].getCategory();
                                tempIngredient.Add(stagedIngredient);
                            }

                            counterTwo++;
                            if(counterTwo >= 3)
                                counterTwo = 0;
                        }
                    }
                    else if(counter == 12)
                    {
                        tempInstr = l;
                        tempNumIngrd = tempIngredient.ToArray().Length;

                        _recipeList.Add(new Recipe(counterID, tempTime, tempPrep, tempServings, tempCalories, tempFat, tempChol, tempSodium, tempCarb, tempFiber, tempProtein, tempNumIngrd, tempName, tempInstr, tempIngredient));
                        _testRecipeList.Add(_recipeList[counterID]);

                        //Increment the counter being used 
                        counterID++;
                    }

                    //Increment the counter and reset it when needed
                    counter++;
                    if(counter >= 13)
                        counter = 0;
                }
                
                //Clean up excess memory
                _recipeList.TrimExcess();
                _testRecipeList.TrimExcess();

                //Return a success signal
                return true;
            }
            else
            {
                /**
                 * \todo Add implementation for adding the error on having a failed recipe input to a log file
                 **/
                Console.WriteLine("ERROR: Recipe File Not Found!");
                return false;
            }
        }
    }
}
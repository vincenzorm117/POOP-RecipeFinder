using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        private static List<Allergy>    _allergyList;        ///< The list used to hold the allergy list read in from file.
        public  static List<Allergy>    _testAllergyList;    ///< List used so that the unit test can have access to the data. Never gets called in the main program.

        private static List<Ingredient> _ingredientList;     ///< The list used to hold the ingredient list read in from file.
        public  static List<Ingredient> _testIngredientList; ///< List used so that the unit test can have access to the data. Never gets called in the main program.

        private static List<Recipe>     _recipeList;         ///< The list used to hold the recipe list read in from file.
        public  static List<Recipe>     _testRecipeList;     ///< List used so that the unit test can have access to the data. Never gets called in the main program.

        /**
         * \fn         public static bool AllergyInput(string path)
         * \brief      Function for reading allergy data in from file.
         * \author     Brian McCormick
         * \param path The path to the input file.
         * \return     A boolean value representing if the process was successful or not.
         * \warning    If the path given is not either a hard-coded direct path or a path relative to where the executable is located
         *             then the allergy input file will not be found.
         * \todo       Add a means of removing and/or ignoring duplicate ID values from the allergy input file.
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
         * \fn         public static bool IngredientInput(string path)
         * \brief      Function for reading ingredient data in from file.
         * \author     Brian McCormick
         * \param path The path to the input file.
         * \return     A boolean value representing if the process was successful or not.
         * \warning    If the path given is not either a hard-coded direct path or a path relative to where the executable is located
         *             then the ingredient input file will not be found.
         * \todo       Add a means of removing and/or ignoring duplicate ID values from the ingredient input file.
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
    }
}
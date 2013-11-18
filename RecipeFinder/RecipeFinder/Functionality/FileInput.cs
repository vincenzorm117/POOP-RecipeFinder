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
         **/
        public static bool AllergyInput(string path)
        {
            //Variables used for controlling the input process
            int      _counter  = 0;
            int      _tempID   = 0;
            string   _tempName = "";
            string[] _lines;
            Allergy  _tempAllergy;

            //Creates a new list of allergy objects
            _allergyList     = new List<Allergy>();
            _testAllergyList = new List<Allergy>();

            //If the file at the target path exists then proceed with the input from file
            if(File.Exists(path))
            {
                //Read in all the lines from file
                _lines = File.ReadAllLines(path);

                //Iterate through all the lines read in from the file
                foreach(string line in _lines)
                {
                    //Test for unwanted lines from the input file: Empty Strings
                    if(line != "")
                    {
                        //Store the data based on the runthrough, on every third iteration create a new allergy object
                        if(_counter == 0)
                            int.TryParse(line, out _tempID);
                        else if(_counter == 1)
                            _tempName = line;
                        else if(_counter == 2)
                        {
                            _tempAllergy = new Allergy(_tempID, _tempName, line);
                            _allergyList.Add(_tempAllergy);
                            _testAllergyList.Add(_tempAllergy);
                        }

                        //Reset the counter after each allergy object creation
                        _counter++;
                        if(_counter >= 3)
                            _counter = 0;
                    }
                }

                //Clean up any extra space not needed
                _allergyList.TrimExcess();

                //Return a success
                return true;
            }
            else
            {
                //Print an error message to the console and return a failed result
                Console.WriteLine("ERROR: Allergy File Not Found!");
                return false;
            }
        }
    

    }
}
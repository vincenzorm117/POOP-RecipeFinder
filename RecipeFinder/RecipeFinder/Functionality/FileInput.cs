using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;

namespace RecipeFinder
{
    public partial class MainWindow : Window
    {
        //Values used for controlling file input
        private string[]      _lines;
        private int           _counter;

        //Lists for storing file input data
        private List<Allergy> _allergyList;

        //Variables for temporarily storing allergy input before calling an objects constructor
        private int           _tempID;
        private string        _tempName;
        private string        _tempMessage;
        private Allergy       _tempAllergy;

        public bool AllergyInput()
        {
            _counter     = 0;
            _allergyList = new List<Allergy>();

            if(File.Exists("allergy.txt"))
            {
                _lines = File.ReadAllLines("allergy.txt");

                foreach(string line in _lines)
                {
                    if(_counter == 0)
                        int.TryParse(line, out _tempID);
                    else if(_counter == 1)
                        _tempName = line;
                    else if(_counter == 2)
                    {
                        _tempAllergy = new Allergy(_tempID, _tempName, line);
                        _allergyList.Add(_tempAllergy);
                    }

                    _counter++;
                    if(_counter >= 3)
                        _counter = 0;
                }

                return true;
            }
            else
            {
                Console.Write("ERROR: Allergy File Not Found!");
                return false;
            }
        }

    }
}
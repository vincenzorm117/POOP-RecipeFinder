using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder
{
    /**
     * \class  Ingredient
     * \brief  Storage for a single Ingredient
     * \author Brian McCormick
     **/
    public class Ingredient
    {
        private int    _ID;      ///< Holds the ID for the stored ingredient
        private int    _Allergy; ///< Holds the ID value of the associated allergy
        private string _Name;    ///< Holds the name of the stored ingredient

        /**
         * \fn     public Ingredient()
         * \brief  Base class constructor.
         * \author Brian McCormick
         **/
        public Ingredient()
        {
            _ID      = -1;
            _Allergy = -1;
            _Name    = "";
        }

        /**
         * \fn      public Ingredient(int i, int a, string n)
         * \brief   Class constructor that initializes all values.
         * \author  Brian McCormick
         * \param i The ingredient ID value.
         * \param a The ingredients allergy ID value.
         * \param n The ingredients name.
         **/
        public Ingredient(int i, int a, string n)
        {
            _ID      = i;
            _Allergy = a;
            _Name    = n;
        }

        /**
         * \fn      public Ingredient(int i, string n)
         * \brief   Class constructor used when no allergy ID is present.
         * \author  Brian McCormick
         * \param i The ingredient ID value.
         * \param n The ingredients name.
         **/
        public Ingredient(int i, string n)
        {
            _ID      = i;
            _Allergy = -1;
            _Name    = n;
        }

        /**
         * \fn     public int getID()
         * \brief  Used for accessing the ingredients ID value.
         * \author Brian McCormick
         * \return The ingredients ID value.
         **/
        public int getID()
        { return _ID;      }

        /**
         * \fn     public int getAllergy()
         * \brief  Used for accessing the ingredients allergy ID value.
         * \author Brian McCormick
         * \return The ingredients allergy ID value.
         **/
        public int getAllergy()
        { return _Allergy; }

        /**
         * \fn     public string getName()
         * \brief  Used for accessing the ingredients name.
         * \author Brian McCormick
         * \return The ingredients name.
         **/
        public string getName()
        { return _Name;    }
    }
}

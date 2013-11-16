using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder
{
    /**
     * \class  Allergy
     * \brief  Storage for a single Allergy
     * \author Brian McCormick
     **/
    public class Allergy
    {
        private int    _ID;      ///< The associated ID number for the stored allergy
        private string _Name;    ///< The name of the allergy stored
        private string _Message; ///< The warning message associated with the stored allergy

        /**
         * \fn      public Allergy(int i, string n, string m)
         * \brief   Class constructor that initializes all values.
         * \author  Brian McCormick
         * \param i The allergy ID value.
         * \param n The name of the allergy.
         * \param m The warning message for the allergy.
         **/
        public Allergy(int i, string n, string m)
        {
            _ID      = i;
            _Name    = n;
            _Message = m;
        }

        /**
         * \fn     public int getID()
         * \brief  Used for accessing the allergy ID value.
         * \author Brian McCormick
         * \return The ID value of the stored allergy.
         **/
        public int getID()
        { return _ID;      }

        /**
         * \fn     public string getName()
         * \brief  Used for accessing the name of the allergy.
         * \author Brian McCormick
         * \return The name of the stored allergy.
         **/
        public string getName()
        { return _Name;    }

        /**
         * \fn     public string getMsg()
         * \brief  Used for accessing the stored allergies warning message.
         * \author Brian McCormick
         * \return The warning message of the stored allergy.
         **/
        public string getMsg()
        { return _Message; }
    }

}

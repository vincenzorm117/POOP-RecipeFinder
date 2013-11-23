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
    public class Allergy : BaseClass
    {
        private string _Message; ///< The warning message associated with the stored allergy

        /**
         * \fn      public Allergy(int i, string n, string m) : base(i, n)
         * \brief   Class constructor that initializes all values.
         * \author  Brian McCormick
         * \param i The allergy ID value.
         * \param n The name of the allergy.
         * \param m The warning message for the allergy.
         **/
        public Allergy(int i, string n, string m) : base(i, n)
        {
            _Message = m;
        }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeFinder
{
    /**
     * \class  BaseClass
     * \brief  The base class for all of this projects classes.
     * \author Brian McCormick
     **/
    public class BaseClass
    {
        private int    _ID;   ///< The ID value associated with the object
        private string _Name; ///< The objects name

        /**
         * \fn     public BaseClass()
         * \brief  The base constructor for the base class.
         * \author Brian McCormick
         **/
        public BaseClass()
        {
            _ID   = -1;
            _Name = "";
        }

        /**
         * \fn           public BaseClass(int i, string n)
         * \brief        Constructor for the base class when all values are passed in.
         * \author       Brian McCormick
         * \param [in] i The index value for the base class object.
         * \param [in] n The name for the base class object.
         **/
        public BaseClass(int i, string n)
        {
            _ID   = i;
            _Name = n;
        }

        /**
         * \fn     public int getID()
         * \brief  Used to get the ID value of the base class object.
         * \author Brian McCormick
         **/
        public int getID()
        { return _ID; }

        /**
         * \fn     public string getName()
         * \brief  Function used to get the name value of the base class object.
         * \author Brian McCormick
         **/
        public string getName()
        { return _Name; }
    }
}
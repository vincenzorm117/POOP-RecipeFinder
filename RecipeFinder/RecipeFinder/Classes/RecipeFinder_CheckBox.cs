using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Collections.Generic;
using System;

namespace RecipeFinder
{
    /**
     * \class  IngredientCheckBox
     * \brief  An extension of the standard checkbox to include storage of 2D list locations.
     * \author Brian McCormick
     **/
    public class IngredientCheckBox : CheckBox
    {
        private int _column; ///< The category that the check box is associated with
        private int _row;    ///< The recipe within the category that the check box is associated with

        /**
         * \fn           public IngredientCheckBox(int c, int r)
         * \brief        The constructor for the new check box class.
         * \author       Brian McCormick
         * \param [in] c The category the check box is associated with.
         * \param [in] r The recipe within the category that the check box is associated with.
         **/
        public IngredientCheckBox(int c, int r) : base()
        {
            //Set the values for mapping purposes
            _column = c;
            _row = r;
        }

        /**
         * \fn     public int getColumn()
         * \brief  Function for accessing the category mapping stored in the check box.
         * \author Brian McCormick
         * \return The category value that the check box is mapped to.
         **/
        public int getColumn()
        { return _column; }

        /**
         * \fn     public int getRow()
         * \brief  Function for accessing the recipe mapping stored in the check box.
         * \author Brian McCormick
         * \return The recipe value that the check box is mapped to.
         **/
        public int getRow()
        { return _row; }
    }

    public class AllergyCheckBox : CheckBox
    {
        private int _index; ///< The index value of the allergy mapped to this check box
        
        /**
         * \fn           public AllergyCheckBox(int i) : base()
         * \brief        Constructor of the Allergy Check Box class.
         * \author       Brian McCormick
         * \param [in] i The index value mapped to this check box.
         **/
        public AllergyCheckBox(int i) : base()
        {
            _index = i;
        }

        /**
         * \fn     public int getIndex()
         * \brief  Function used for getting the index value mapped to this check box.
         * \author Brian McCormick
         * \return The stored index value.
         **/
        public int getIndex()
        { return _index; }
    }
}
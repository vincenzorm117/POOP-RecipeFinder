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
    public class Ingredient : BaseClass
    {
        private int                _Allergy;    ///< Holds the ID value of the associated allergy
        private IngredientCategory _Category;   ///< Holds the category that the ingredient belongs to
        private int                _CategoryID; ///< Holds the position within the category list indicated by the _category value

        /**
         * \fn     ppublic Ingredient() : base()
         * \brief  Base class constructor.
         * \author Brian McCormick
         **/
        public Ingredient() : base()
        {
            _Allergy    = -1;
            _Category   = IngredientCategory.NONE;
            _CategoryID = -1;
        }

        /**
         * \fn      public Ingredient(int i, int a, string n, IngredientCategory c) : base(i, n)
         * \brief   Class constructor that initializes all values except for the category ID.
         * \author  Brian McCormick
         * \param i The ingredient ID value.
         * \param a The ingredients allergy ID value.
         * \param n The ingredients name.
         * \param c The category that the ingredient belongs to.
         **/
        public Ingredient(int i, int a, string n, IngredientCategory c) : base(i, n)
        {
            _Allergy    = a;
            _Category   = c;
            _CategoryID = -1;
        }

        /**
         * \fn      public Ingredient(int i, string n, IngredientCategory c) : base(i, n)
         * \brief   Class constructor used when no allergy ID is present and doesn't initialize the category ID.
         * \author  Brian McCormick
         * \param i The ingredient ID value.
         * \param n The ingredients name.
         * \param c The category that the ingredient belongs to.
         **/
        public Ingredient(int i, string n, IngredientCategory c) : base(i, n)
        {
            _Allergy    = -1;
            _Category   = c;
            _CategoryID = -1;
        }

        /**
         * \fn               pupublic Ingredient(Ingredient other) : base(other.getID(), other.getName())
         * \brief            Class constructor used for creating an ingredient object from another ingredient object.
         * \author           Brian McCormick
         * \param [in] other The ingredient object used to create the new ingredient object.
         **/
        public Ingredient(Ingredient other) : base(other.getID(), other.getName())
        {
            _Allergy    = other._Allergy;
            _Category   = other._Category;
            _CategoryID = other._CategoryID;
        }

        /**
         * \fn             public void setCategoryID(int cid)
         * \brief          Used for setting the category id value for the ingredient.
         * \author         Brian McCormick
         * \author         Ronald Hyatt
         * \date           Created Date: 11/18/2013
         * \param [in] cid The category id to assign to the ingredient.
         **/
        public void setCategoryID(int cid)
        { _CategoryID = cid;  }

        /**
         * \fn     public int getAllergy()
         * \brief  Used for accessing the ingredients allergy ID value.
         * \author Brian McCormick
         * \return The ingredients allergy ID value.
         **/
        public int getAllergy()
        { return _Allergy;    }

        /**
         * \fn     public IngredientCategory getCategory()
         * \brief  Used for accessing the ingredients category value.
         * \author Brian McCormick
         * \return The ingredients category value.
         **/
        public IngredientCategory getCategory()
        { return _Category;   }

        /**
         * \fn     public int getCategoryID()
         * \brief  Used for accessing the ingredients category id.
         * \author Brian McCormick
         * \return The ingredients category id.
         **/
        public int getCategoryID()
        { return _CategoryID; }


        public void printIngredient()
        {
            Console.WriteLine();
            Console.WriteLine("\tActual   Results -> ID: {0}\tName: {1}\tAllergy: {2}\tCategory: {3}\tCategory ID: {4}", this.getID(), this.getName(), _Allergy, _Category, _CategoryID);
        }
    }
}

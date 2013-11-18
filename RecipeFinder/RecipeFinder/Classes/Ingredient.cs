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
        private int                _ID;         ///< Holds the ID for the stored ingredient
        private int                _Allergy;    ///< Holds the ID value of the associated allergy
        private string             _Name;       ///< Holds the name of the stored ingredient
        private IngredientCategory _Category;   ///< Holds the category that the ingredient belongs to
        private int                _CategoryID; ///< Holds the position within the category list indicated by the _category value

        /**
         * \fn     public Ingredient()
         * \brief  Base class constructor.
         * \author Brian McCormick
         **/
        public Ingredient()
        {
            _ID         = -1;
            _Allergy    = -1;
            _Name       = "";
            _Category   = IngredientCategory.NONE;
            _CategoryID = -1;
        }

        /**
         * \fn      public Ingredient(int i, int a, string n, IngredientCategory c)
         * \brief   Class constructor that initializes all values except for the category ID.
         * \author  Brian McCormick
         * \param i The ingredient ID value.
         * \param a The ingredients allergy ID value.
         * \param n The ingredients name.
         * \param c The category that the ingredient belongs to.
         **/
        public Ingredient(int i, int a, string n, IngredientCategory c)
        {
            _ID         = i;
            _Allergy    = a;
            _Name       = n;
            _Category   = c;
            _CategoryID = -1;
        }

        /**
         * \fn      public Ingredient(int i, string n, IngredientCategory c)
         * \brief   Class constructor used when no allergy ID is present and doesn't initialize the category ID.
         * \author  Brian McCormick
         * \param i The ingredient ID value.
         * \param n The ingredients name.
         * \param c The category that the ingredient belongs to.
         **/
        public Ingredient(int i, string n, IngredientCategory c)
        {
            _ID         = i;
            _Allergy    = -1;
            _Name       = n;
            _Category   = c;
            _CategoryID = -1;
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
         * \fn     public int getID()
         * \brief  Used for accessing the ingredients ID value.
         * \author Brian McCormick
         * \return The ingredients ID value.
         **/
        public int getID()
        { return _ID;         }

        /**
         * \fn     public int getAllergy()
         * \brief  Used for accessing the ingredients allergy ID value.
         * \author Brian McCormick
         * \return The ingredients allergy ID value.
         **/
        public int getAllergy()
        { return _Allergy;    }

        /**
         * \fn     public string getName()
         * \brief  Used for accessing the ingredients name.
         * \author Brian McCormick
         * \return The ingredients name.
         **/
        public string getName()
        { return _Name;       }

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
    }
}

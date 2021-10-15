using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magicFactory
{
    public class Recipes 
    {
        public static List<Recipes> ListOfAllRecipes { get; private set; }         
                                                                            
        public string Name { get; } 
        public int WoodNeeded { get; } // Wood needed to create this recipe
        public int IronNeeded { get; } // Iron needed to create this recipe
        public int RubberNeeded { get; } // Rubber needed to create this recipe
        public int SumAllMaterialNeeded { get; } // WoodNeeded + IronNeeded + RubberNeeded. Används för att värdera villket färemål att tillverka.
                                                 // Göra till metod istället för fält? 

        public Recipes(string name, int woodNeeded=0, int ironNeeded=0, int rubberNeeded = 0, bool AddToList = true) // Konstruktor
                                                                    // make more constructors?                                                                     
        {                                                            // Lägga till i lista direkt? --gjort
            Name = name;
            WoodNeeded = woodNeeded;
            IronNeeded = ironNeeded;
            RubberNeeded = rubberNeeded;
            SumAllMaterialNeeded = WoodNeeded + IronNeeded + RubberNeeded; // metod istället?

            if (AddToList == true) // förhindra dubletter i ListOfAllRecipes <--- förbättra. Fler kontruktorer? flytta add to list?
            {
                ListOfAllRecipes.Add(this); // lägg till recept i lista över alla recept
            }
        }
        public static void CreateRecipes() // populate ListOfAllRecipes at start
        {
            ListOfAllRecipes = new List<Recipes>();
            ListOfAllRecipes.AddRange(new List<Recipes>
            {
                new Recipes("axe", 1, 1, 0, false),
                new Recipes("plunger", 1, 0, 1, false),
                new Recipes("chopsticks", 1, 0, 0, false),
                new Recipes("bikecycle", 0, 3, 1, false)
             });
        }


    }
}


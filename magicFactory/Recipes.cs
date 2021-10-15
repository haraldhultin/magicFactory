using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magicFactory
{
    public class Recipes 
    {
        public static List<Recipes> _listOfAllRecipes { get; private set; }
         
                                                                            // access through static method?
                                                                            // Nya recept läggs till i listan viaRecipe-konstruktor
                                                                            // private set?
        public string Name { get; } 
        public int WoodNeeded { get; } // Wood needed to create this recipe
        public int IronNeeded { get; } // Iron needed to create this recipe
        public int RubberNeeded { get; } // Rubber needed to create this recipe
        public int SumAllMaterialNeeded { get; } // WoodNeeded + IronNeeded + RubberNeeded. Används för att värdera villket färemål att tillverka.
                                                 // Göra till metod istället för fält? 

        public Recipes(string name, int woodNeeded=0, int ironNeeded=0, int rubberNeeded = 0) // Konstruktor
                                                                    // make more constructors?                                                                     
        {                                                            // Lägga till i lista direkt? --gjort
            Name = name;
            WoodNeeded = woodNeeded;
            IronNeeded = ironNeeded;
            RubberNeeded = rubberNeeded;
            SumAllMaterialNeeded = WoodNeeded + IronNeeded + RubberNeeded; // metod istället?
            _listOfAllRecipes.Add(this);
        }
        public static void CreateRecipes() // populate _listOfAllRecipes at start of game
        {
            _listOfAllRecipes = new List<Recipes>();
            Recipes axe = new Recipes("axe", 2, 1, 0);
            Recipes plunger = new Recipes("plunger", 1, 0, 1);
            Recipes chopsticks = new Recipes("chopsticks", 1, 0, 0);
            Recipes bikecycle = new Recipes("bikecycle", 0, 3, 1);
        }



        //public static void ShowListOfRecipes() // needed? Remove?
        //{
        //    Console.WriteLine($"{ "Name",-10} { "Wood",-5} {"Iron",-5} {"Rubber"}");
        //    Console.WriteLine("----------------------------");
        //    foreach (var item in _listOfAllRecipes)
        //    {
        //        Console.WriteLine($"{ item.Name,-10} { item.WoodNeeded,-5} { item.IronNeeded,-5} {item.RubberNeeded}");
        //    }
        //}
    }
}


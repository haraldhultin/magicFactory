using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magicFactory
{
    public class Recipes // lägg i array av recipies. Egna klasser eller bara instanser?
    {
        public static List<Recipes> _listOfAllRecipes = new List<Recipes>(); // statisk lista äver alla recept.
                                                                             // Nya recept läggs till i listan viaRecipe-konstruktor
     
        public string Name { get; } 
        public int WoodNeeded { get; } // Wood needed to create this recipe
        public int IronNeeded { get; } // Iron needed to create this recipe
        public int RubberNeeded { get; } // Rubber needed to create this recipe
        public int SumAllMaterialNeeded { get; } // WoodNeeded + IronNeeded + RubberNeeded. Används för att värdera villket färemål att tillverka.
                                                 // Göra till metod istället för fält? 

        public Recipes(string name, int wood, int iron, int rubber) // Konstruktor
                                                                    // make more constructors?                                                                     
        {                                                            // Lägga till i lista direkt? --gjort
            Name = name;
            WoodNeeded = wood;
            IronNeeded = iron;
            RubberNeeded = rubber;
            SumAllMaterialNeeded = WoodNeeded + IronNeeded + RubberNeeded;
            _listOfAllRecipes.Add(this);
        }
        public static void CreateRecipes() // populate _listOfAllRecipes at start of game
        {
            Recipes axe = new Recipes("axe", 2, 1, 0);
            Recipes plunger = new Recipes("plunger", 1, 0, 1);
            Recipes chopsticks = new Recipes("chopsticks", 1, 0, 0);
            Recipes bikecycle = new Recipes("bikecycle", 0, 3, 1);
        }
        public static void ShowListOfRecipes() // needed? Remove?
        {
            Console.WriteLine($"{ "Name",-10} { "Wood",-5} {"Iron",-5} {"Rubber"}");
            Console.WriteLine("----------------------------");
            foreach (var item in _listOfAllRecipes)
            {
                Console.WriteLine($"{ item.Name,-10} { item.WoodNeeded,-5} { item.IronNeeded,-5} {item.RubberNeeded}");
            }
        }
    }
}


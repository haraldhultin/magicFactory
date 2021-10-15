using System;
using System.Collections.Generic;
using magicFactory;
namespace magicFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            // test3 coomit branch "test" <----
            // test2 commit branch "test" <-------
            // testa commit.. <------
  
            Game newGame = new Game();    // onädigt? lägga i game? göra Start() static?        
            newGame.Start();         
            

            /* inventory lista
             * matcha
             * material /base sen random? lägga i materiallista
             * switcha in?
             * kolla inventory
             * när välja item i inventory 1.Iron = _inventoryList[n-1];
             */
            //Inventory inv = new Inventory();
            //inv.CreateInventoryList();


            //inv.CreateInventoryList(); // göra static? --gjort
            //inv.ShowInventory();
            //Recipes axe = new Recipes("axe", 2, 1, 0);// lägga i create recipies metod? skapa allt lägga i lista?
            //Recipes plunger = new Recipes("plunger", 1, 0, 1);
            //Recipes chopsticks = new Recipes("chopsticks", 1, 0, 0);
            //Recipes bikecycle = new Recipes("bikecycle", 0, 3, 1);
            //Recipes.ShowListOfRecipes(); // listar alla recept + kostnat i material
            //List<string> MaterialToFactory = new List<string>();            
        }
    }
}

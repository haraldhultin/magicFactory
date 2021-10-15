using System;
using System.Collections.Generic;
using magicFactory;
namespace magicFactory
{
    class Program
    {
        static void Main(string[] args)

        {
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


            //inv.CreateInventoryList(); // göra static? Kankse inte ...
            //inv.ShowInventory();
            //List<string> MaterialToFactory = new List<string>();            
        }
    }
}

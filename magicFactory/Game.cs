using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace magicFactory
{
    public class Game
    {        
        
        public Game()
        {           
        }
        public void Start()
        {
            //Recipes recipes = new Recipes();
            Inventory inventory = new Inventory();
            Recipes.CreateRecipes(); // skapa receptlista
            inventory.ChooseMaterialToSendToFactory();
        }
        
    }
}

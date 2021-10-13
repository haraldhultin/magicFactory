using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace magicFactory
{
    class Factory
    {
        private int _woodInFactory;
        private int _ironInFactory;
        private int _rubberInFactory;

        public void MaterailFromUser(int wood, int iron, int rubber)
        {
            Console.WriteLine("Hello from factory");
            _woodInFactory = wood;
            _ironInFactory = iron;
            _rubberInFactory = rubber;
            CheckMaterialAgainstRecepies();//_wood, _iron, _rubber
        }
        private void CheckMaterialAgainstRecepies()
        {
            int topTotalMaterial = 0;
            int indexOfTopRecipe = 0;
            foreach (var item in Recipes._listOfAllRecipes)
            {
                if (item.WoodNeeded <= _woodInFactory && item.IronNeeded <= _ironInFactory && item.RubberNeeded <= _rubberInFactory)
                {
                    if (item.SumAllMaterialNeeded > topTotalMaterial)
                    {
                        topTotalMaterial = item.SumAllMaterialNeeded;
                        indexOfTopRecipe = Recipes._listOfAllRecipes.IndexOf(item);
                    }
                }
            }

            
            if (Recipes._listOfAllRecipes[indexOfTopRecipe].WoodNeeded <= _woodInFactory &&
                Recipes._listOfAllRecipes[indexOfTopRecipe].IronNeeded<= _ironInFactory &&
                Recipes._listOfAllRecipes[indexOfTopRecipe].RubberNeeded <= _rubberInFactory)
            {
                Console.WriteLine("item to create: {0}", Recipes._listOfAllRecipes[indexOfTopRecipe].Name); 
                CreateItemFromRecipe(Recipes._listOfAllRecipes[indexOfTopRecipe]);
            }
            else
            {
                Console.WriteLine("Found noting to create ");
            }
        }

        private void CreateItemFromRecipe(Recipes recipe)
        {
            Random timeRando = new();
            Console.Write("Gathering rescourses ");
                string dotdotdot = ".";
            for (int i = 0; i < 10; i++)
            {
                Console.Write(dotdotdot);                                        
                if (i%4 == 0) { Console.Write("\b\b\b   \b\b\b"); }
                Thread.Sleep(timeRando.Next(50, 400));
            }
            Console.WriteLine();

            Console.WriteLine("Construction of {0} is starting ...", recipe.Name);
            Thread.Sleep(timeRando.Next(50, 400));
            Inventory.PlayerItems.Add(recipe);
            //Console.WriteLine("itemlist count: {0}", Inventory.PlayerItems.Count);
            Console.WriteLine("Success!");
            Console.WriteLine("The {0} was added to your inventory.", recipe.Name);
            Thread.Sleep(700);
            Console.WriteLine("Checking if there anything else to make ..");

            _woodInFactory -= recipe.WoodNeeded; // ta bort material från inv i fabrik
            _ironInFactory -= recipe.IronNeeded;
            _rubberInFactory -= recipe.IronNeeded;
            CheckMaterialAgainstRecepies(); // kör 
            
            Inventory.UpdateAndCleanUpInventory(_woodInFactory, _ironInFactory,_rubberInFactory);
            Console.WriteLine("Your remaining material has been returned.");
            _woodInFactory = 0;
            _ironInFactory = 0;
            _rubberInFactory = 0;

            //Console.WriteLine("trä: {0} järn: {1} gummi: {2}", _woodInFactory, _ironInFactory, _rubberInFactory);

        }

        
    }
}

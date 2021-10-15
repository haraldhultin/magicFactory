using System;
namespace magicFactory 
{
    class Factory : Inventory
    {
        private int _woodInFactory;
        private int _ironInFactory;
        private int _rubberInFactory;

        public void MaterailFromUser(int wood, int iron, int rubber)
        {
            _woodInFactory = wood;
            _ironInFactory = iron;
            _rubberInFactory = rubber;
            CheckMaterialInFactoryAgainstRecepies(); //_wood, _iron, _rubber
        }
        private void CheckMaterialInFactoryAgainstRecepies()
        {
            
                int topTotalMaterial = -1;
                int indexOfTopRecipe = -1;
            foreach (var item in Recipes.ListOfAllRecipes)
            {
                if (item.WoodNeeded <= _woodInFactory &&
                    item.IronNeeded <= _ironInFactory &&
                    item.RubberNeeded <= _rubberInFactory) 
                {
                    if (item.SumAllMaterialNeeded > topTotalMaterial)
                    {
                        topTotalMaterial = item.SumAllMaterialNeeded;
                        indexOfTopRecipe = Recipes.ListOfAllRecipes.IndexOf(item); // byta till name?                                                          
                    }
                }
            }

            if (indexOfTopRecipe != -1)
            {                
                CreateItemFromRecipe(Recipes.ListOfAllRecipes[indexOfTopRecipe]);
            }
            else
            {
                Console.WriteLine("Found nothing else to create ");                
                ReturnMaterialFromFabricToInventory(_woodInFactory, _ironInFactory, _rubberInFactory);
            }                                                 
        }                                                    

        private void CreateItemFromRecipe(Recipes recipe)
        {
            Console.WriteLine("Creating {0}", recipe.Name);
            Inventory.PlayerItems.Add(recipe);

            _woodInFactory -= recipe.WoodNeeded; // Remove material used in creation of itemm
            _ironInFactory -= recipe.IronNeeded;
            _rubberInFactory -= recipe.RubberNeeded;
            CheckMaterialInFactoryAgainstRecepies(); // check again        
        }


    }
}

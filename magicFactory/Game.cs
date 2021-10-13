using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace magicFactory
{
    public class Game
    {        
        private int _wood;
        private int _iron;
        private int _rubber;
        public static List<int> indexSelectedMaterial = new();
        public static int inputIndex;
        public Game()
        {           
        }
        public void Start()
        {
            Recipes.CreateRecipes(); // skapa receptlista
            Inventory inv = new Inventory();
            ChooseMaterialFromInvToSendToFactory();
        }
        public void ChooseMaterialFromInvToSendToFactory() // välja att skicka
        {
            while (_wood + _iron + _rubber < 5)
            {
                //myList.Clear();
                Inventory.ShowInventory();
                Console.WriteLine($"{"Wood: " + _wood,-5} {"Iron: " + _iron,-5} {"Rubber " + _rubber}");
                Console.WriteLine("Press number to add material to shipment...");
                //inputIndex = Convert.ToInt32(Console.ReadKey(true).KeyChar.ToString()); // ej typsäkrat
                inputIndex = Convert.ToInt32(Console.ReadLine()); // ej typsäkrat

                Console.Clear();

                if (!indexSelectedMaterial.Contains(inputIndex - 1))
                {
                    switch (Inventory.InventoryList[inputIndex - 1])
                    {
                        case "Wood":
                            _wood += 1;
                            break;
                        case "Iron":
                            _iron += 1;
                            break;
                        case "Rubber":
                            _rubber += 1;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Already selected");
                }
                Inventory.InventoryList[inputIndex - 1] = "XXXX";
                indexSelectedMaterial.Add(inputIndex - 1);
            }
            Factory factory = new Factory();
            factory.MaterailFromUser(_wood, _iron, _rubber);
        }
    }
}

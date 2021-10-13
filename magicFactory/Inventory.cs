using System;
using System.Collections.Generic;

namespace magicFactory
{
    public class Inventory
    {
        private static string _filler = "XXXX";
        private static List<string> _inventoryList;
        private static List<Recipes> _playerItems = new();

        public static List<Recipes> PlayerItems { get => _playerItems; set => _playerItems = value; }
        public static List<string> InventoryList { get => _inventoryList; set => _inventoryList = value; }

        private static readonly string[] MaterialArray = { "Wood", "Iron", "Rubber" }; // lägga i enum? Flytta ut?
        private static readonly int _capacityStorage = 15;
        static Random randomInventory = new Random();
        public Inventory()
        {
            InventoryList = new List<string>(); // Skapa lista inv
            PlayerItems = new List<Recipes>(); // Skapa lista över tillverkade saker tillbaks från fabrik
            CreateInventoryList();            // populate list of materal att välja från
        }

        public void CreateInventoryList() // Fyll lista över material
        {
            for (int i = 0; i < _capacityStorage; i++)
            {
                InventoryList.Add(MaterialArray[randomInventory.Next(0, MaterialArray.Length)]);
            }

        }

        public static void ShowInventory() // printa vad som finns i inventory
        {
            int numPrint = 1; // för att kunna skriva i tre spalter men numrera vertikalt

            for (int i = 1; i <= InventoryList.Count; i++)
            {
                if (i % 3 != 0)
                {
                    Console.Write($"{numPrint + " " + InventoryList[numPrint - 1],-15}");
                    numPrint += 5;
                }
                else
                {
                    Console.Write($"{numPrint + " " + InventoryList[numPrint - 1],-15}");
                    Console.WriteLine();
                    numPrint -= 9;
                }
            }
        }
        public static void UpdateAndCleanUpInventory(int wood, int iron, int rubber)
        {
            int[] ParaArray = { wood, iron, rubber };
            for (int n = 0; n < ParaArray[n]; n++)
            {
                _inventoryList.Add(MaterialArray[n]);
                Console.WriteLine("nu addas " + MaterialArray[n]);

                //for (int i = 0; i < ;  i++)
                //{
                //    Console.WriteLine(MaterialArray[i].ToLower());
                //    //_inventoryList.Add(MaterialArray[n]);
                //}
                Console.WriteLine("sista ele: " + _inventoryList[_inventoryList.Count - 1]);
            }

            int index = 0;
            for (int i = 0; i < _capacityStorage; i++) // Add created item returned from factory to i_nventoryList
            {
                if (_inventoryList[i] == _filler)
                {
                    if (index <= _playerItems.Count - 1)
                    {
                        _inventoryList[i] = _playerItems[index].Name;
                        index++;
                        break;
                    }
                }

            }
            //for (int i = 0; i < _capacityStorage; i++) // To fill up emty spaces in inventory with new inventory
            //{
            //    if (_inventoryList[i] == _filler)
            //    {
            //        _inventoryList[i] = MaterialArray[randomInventory.Next(0, MaterialArray.Length)];
            //    }
            //}
            ShowInventory();
        }
    }
}




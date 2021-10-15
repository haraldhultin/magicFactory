using System;
using System.Collections.Generic;

namespace magicFactory
{
    public class Inventory
    {
        public static List<int> indexSelectedMaterial = new();
        private static string _filler = "XXXX";
        private  List<string> _inventoryList;
        private  List<Recipes> _playerItems = new();

        public  List<Recipes> PlayerItems { get => _playerItems; set => _playerItems = value; }
        public  List<string> InventoryList { get => _inventoryList; set => _inventoryList = value; }

        private  readonly string[] MaterialArray = { "Wood", "Iron", "Rubber" }; // lägga i enum? Flytta ut?
        private  readonly int _capacityStorage = 15;
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

        public void ShowInventory() // printa vad som finns i inventory
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
        public void ChooseMaterialToSendToFactory() // välja att skicka
        {
            int inputIndex;
            int _wood = 0;
            int _iron = 0;
            int _rubber = 0;
            while (_wood + _iron + _rubber < 5)
            {
                //myList.Clear();
                ShowInventory();
                Console.WriteLine($"{"Wood: " + _wood,-5} {"Iron: " + _iron,-5} {"Rubber " + _rubber}");
                Console.WriteLine("Press number to add material to shipment...");
                //inputIndex = Convert.ToInt32(Console.ReadKey(true).KeyChar.ToString()); // ej typsäkrat
                inputIndex = Convert.ToInt32(Console.ReadLine()); // ej typsäkrat

                Console.Clear();

                if (!indexSelectedMaterial.Contains(inputIndex - 1))
                {
                    switch (InventoryList[inputIndex - 1])
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
                InventoryList[inputIndex - 1] = "XXXX";
                indexSelectedMaterial.Add(inputIndex - 1);
            }
            Factory factory = new Factory();
            factory.MaterailFromUser(_wood, _iron, _rubber);
        }
        public void UpdateAndCleanUpInventory(int wood, int iron, int rubber)
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




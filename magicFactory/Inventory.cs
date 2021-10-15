using System;
using System.Collections.Generic;

namespace magicFactory
{
    public class Inventory
    {
        int woodInShipment = 0;
        int ironInShipment = 0;
        int rubberInShipment = 0;
        public List<int> indexSelectedMaterial = new();
        public static List<Recipes> PlayerItems { get; set; }
        public static List<string> ListOfMaterialInInventory { get; set; }

        private readonly int _capacityInventory = 15;
        static Random random = new Random();
        public Inventory()
        {
            ListOfMaterialInInventory = new List<string>(); // Skapa lista inv
            PlayerItems = new List<Recipes>();              // Skapa lista över tillverkade saker tillbaks från fabrik
            PopulateInventoryList();                        // populate list of materal att välja från
        }

        public void PopulateInventoryList()                 // Populate ListOfMaterialInInventory with random elements from EnumMaterial
        {
            for (int i = 0; i < _capacityInventory; i++)
            {
                int lengthOfEnum = Enum.GetNames(typeof(EnumMaterial)).Length; // Lenght of EnumMaterial
                ListOfMaterialInInventory.Add(Convert.ToString((EnumMaterial)random.Next(0, lengthOfEnum))); // Populate ListOfMaterialInInventory with material at random index                      
            }
        }

        public void ShowInventory() // printa vad som finns i inventory
        {
            int specialColumnIndex = 1; // för att kunna skriva i tre spalter men numrera vertikalt
            for (int i = 1; i <= ListOfMaterialInInventory.Count; i++)
            {
                if (i % 3 != 0)
                {
                    Console.Write($"{specialColumnIndex + " " + ListOfMaterialInInventory[specialColumnIndex - 1],-15}");
                    specialColumnIndex += 5;
                }
                else
                {
                    Console.Write($"{specialColumnIndex + " " + ListOfMaterialInInventory[specialColumnIndex - 1],-15}");
                    Console.WriteLine();
                    specialColumnIndex -= 9;
                }
            }
        }
        public void ChooseWhatMaterialToSendToFactory() // välja att skicka
        {
            int maxAmountMaterialToShip = 5;
            int inputIndex;            

            while (woodInShipment + ironInShipment + rubberInShipment < maxAmountMaterialToShip)
            {
                ShowInventory();
                Console.WriteLine($"{"Wood: " + woodInShipment,-5} {"Iron: " + ironInShipment,-5} {"Rubber " + rubberInShipment}"); // förbättra. loopa fram? array? 
                Console.WriteLine("Enter number to add material to shipment...");
                inputIndex = Convert.ToInt32(Console.ReadLine()); // ej typsäkrat
                CountMaterialInShippment(inputIndex);
                Console.Clear();
                if (indexSelectedMaterial.Contains(inputIndex))
                {
                    Console.WriteLine("Alredy chosen.");
                }
                else
                {
                    indexSelectedMaterial.Add(inputIndex - 1);
                    ListOfMaterialInInventory[inputIndex - 1] = "";
                }
            }
            Factory factory = new Factory();
            factory.MaterailFromUser(woodInShipment, ironInShipment, rubberInShipment);
        }

        public void ReturnMaterialFromFabricToInventory(int wood, int iron, int rubber)
        {
            // fixa inventorylist <----------

            //ShowInventory();
            //Console.WriteLine("banan");
            // int[] ParaArray = { wood, iron, rubber };
            //for (int n = 0; n < ParaArray.Length; n++)
            //{
            //    for (int i = 0; i < ParaArray[n]; i++)
            //    {
            //        for (int k = 0; k < ListOfMaterialInInventory.Count; k++)
            //        {
            //            if (ListOfMaterialInInventory[k] == "")
            //            {
            //                ListOfMaterialInInventory[k]=Convert.ToString((EnumMaterial)n);
            //                break;
            //            }
            //        }                        

            //    }
            //}


            //int index = 0;
            //for (int i = 0; i < _capacityStorage; i++) // Add created item returned from factory to i_nventoryList
            //{

            //    {
            //        if (index <= _playerItems.Count - 1)
            //        {
            //            _inventoryList[i] = _playerItems[index].Name;
            //            index++;
            //            break;
            //        }
            //    }

            //    }
            //    //for (int i = 0; i < _capacityStorage; i++) // To fill up emty spaces in inventory with new inventory
            //    //{
            //    //    if (_inventoryList[i] == _filler)
            //    //    {
            //    //        _inventoryList[i] = MaterialArray[randomInventory.Next(0, MaterialArray.Length)];
            //    //    }
            //    //}
            //    ShowInventory();
            //}
        }
        private void CountMaterialInShippment(int inputIndex)
        {
            switch (ListOfMaterialInInventory[inputIndex - 1])
            {
                case "Wood":
                    woodInShipment += 1;
                    break;
                case "Iron":
                    ironInShipment += 1;
                    break;
                case "Rubber":
                    rubberInShipment += 1;
                    break;
                default:
                    break;
            }
        }
    }
}





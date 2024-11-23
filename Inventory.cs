using System.Collections;

namespace InvManager
{
    class Inventory
    {

        public Inventory()
        {
            //empty Constructor
        }
        public Dictionary<int, InventoryItem> inventory =      // making dictionary (hashtable), int is a key, this will be ID
            new Dictionary<int, InventoryItem>();

        public void SetID(InventoryItem item)
        {
            int index = inventory.Count + 1;                   // gets the amount of items in inventory, add one
            item.ID = index;                               // Set the count to items ID
        }
        public void AddToInventory(InventoryItem item)
        {
            SetID(item);
            inventory.TryAdd(item.ID, item);
            Console.WriteLine("Inventory item added with ID " + item.ID + "\n");  
        }

        public void AddToInventory(InventoryItem item, int _quantity)       // can add multiple of the same item
        {
            for(int i = 0; i < _quantity; i++ )                         
            {
                AddToInventory(item);                                  
            }  
        }

        public void RemoveFromInventory(int key)
        {
            inventory.Remove(key);
        }

        public void RemoveFromInventory(string sku)                         // removes bulk items based off sku, will make another based of status
        {
            foreach(KeyValuePair<int, InventoryItem> entry in inventory)    //  I do not know if removing while in a foreach loop creates a problem while iterating!!!
            {
                if(entry.Value.SKU == sku)
                {
                    RemoveFromInventory(entry.Key);
                }
            }
        }

        public InventoryItem GetItem(int key)
        {
            return inventory[key];
        }

        public InventoryItem[] GetList()
        {
            int length = inventory.Count()-1;
            InventoryItem[] list = new InventoryItem[length];                // makes an array with the same size as the dictionary
            IDictionaryEnumerator InvEnum = inventory.GetEnumerator();       // makes an enumorator of dictionary
            int count = 0;
            while(InvEnum.MoveNext())
            {
                list[count] = (InventoryItem)InvEnum.Current;                // while enumorator is cycling through entry, put current entry into array
                count++;                                                     // move to next entry. 
            }

            return list;

        }

    

    }
}

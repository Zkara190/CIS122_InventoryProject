using System.Collections;

namespace InvManager
{
    class Inventory
    {

        int BUCKET; //v estigial
        Dictionary<int, InventoryItem> inventory =      // making dictionary, int is a key, this will be ID
            new Dictionary<int, InventoryItem>();

        public void AddToInventory(InventoryItem item)
        {
            int count = inventory.Count+1;                                        // get the number of items in dictionary, next item is that plus 1
            inventory.TryAdd(count, item);
            Console.WriteLine("Inventory item added with ID " + count + "\n");  // needs to change Items ID number based on position in dictionary
              

        }

        public void AddToInventory(InventoryItem item, int _quantity)       // can add multiple of the same item
        {
            for(int i = 0; i < _quantity; i++ )                         
            {
                AddToInventory(item);                                       // needs to change Items ID number based on position in dictionary
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

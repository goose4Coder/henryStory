using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    // Start is called before the first frame update
    protected List<InventoryItem> inventoryItems;
    protected uint inventoryLimit = 0;

    public void AddItem(InventoryItem itemToAdd)
    {
        if (inventoryLimit!=0 && inventoryItems.Count + 1 <= inventoryLimit)
        {
            inventoryItems.Add(itemToAdd);
        }
    }

    public void RemoveItem(int indexToClear)
    {
        inventoryItems.RemoveAt(indexToClear);
    }

    public bool IsFull() 
    {
        if (inventoryLimit!=0 && inventoryItems.Count==inventoryLimit){
            return true;
        }
        return false;
    }

    public bool IsItemPresent(string nameOfItem) 
    {
        foreach (InventoryItem item in inventoryItems){
            if (item.GetName() == nameOfItem)
            {
                return true;
            }
        }
        return false;
    }

    public int InventoryItemsCount()
    {
        return inventoryItems.Count;
    }

    public List<InventoryItem> GetInventoryItems()
    {
        return inventoryItems;
    }
}

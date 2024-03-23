using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryViewerControl : MonoBehaviour, IInitializable
{
    // Start is called before the first frame update
    GameObject viewer;
    GameObject inventoryObjectAttached;
    List<GameObject> inventorySlots;
    public virtual void Initialize(int initializedInOrder)
    {
        viewer = gameObject;
    }
    public void Close()
    {
        viewer.SetActive(false);
        foreach(GameObject slot in inventorySlots)
        {
            slot.GetComponent<InventorySlotControl>().Clear();
        }
    }

    public void ShowInventory(Inventory toShow)
    {
        for(int i = 0; i < toShow.InventoryItemsCount() && i < inventorySlots.Count; i++)
        {
            inventorySlots[i].GetComponent<InventorySlotControl>().SetItem(toShow.GetInventoryItems()[i]);
        }
    }
    
}

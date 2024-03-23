using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotControl : MonoBehaviour,IInitializable
{
    // Start is called before the first frame update
    InventoryItem currentItem;
    GameObject slot;
    RawImage slotImage;

    public void Initialize(int initializedInOrder)
    {
        slot = gameObject;
        slotImage = slot.GetComponent<RawImage>();
    }

    public void Clear()
    {
        slotImage.texture = new Texture2D(320, 320);
        currentItem = null;

    }

    public void SetItem(InventoryItem item)
    {
        slotImage.texture = item.GetImage();
        currentItem = item;
    }
}

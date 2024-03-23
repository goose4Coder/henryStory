using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    protected string name;
    protected string imageName;
    protected Texture2D itemImage;
    // Start is called before the first frame update
    InventoryItem(string nameToSet, string imageNameToLoad)
    {
        this.name = nameToSet;
        this.imageName = imageNameToLoad;
        TextAsset imageBytes= (TextAsset)Resources.Load("ItemSprites/" + imageNameToLoad);
        this.itemImage= new Texture2D(320, 320);
        itemImage.LoadImage(imageBytes.bytes);

    }
    public string GetName()
    {
        return this.name;
    }

    public Texture2D GetImage()
    {
        return this.itemImage;
    }
}

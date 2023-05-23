using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class InventoryItem 
{

    public ItemData itemData;
    public string inspectText;
    // Start is called before the first frame update
    public InventoryItem(ItemData item)
    {
        itemData = item;
        inspectText = item.inspectText;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

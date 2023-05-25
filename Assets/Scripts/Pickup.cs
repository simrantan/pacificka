using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Collectable
{
    public static event HandleItemCollected OnItemCollected;
    public delegate void HandleItemCollected(ItemData itemData);
    public ItemData item_data;

    protected override void OnCollect() {
        if(collected == false) {
        OnItemCollected?.Invoke(item_data);
        base.OnCollect();
        }

    }
}

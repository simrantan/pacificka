using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Inventory : MonoBehaviour
{

    public static event Action<List<InventoryItem>> OnInventoryChange;
    public static List<InventoryItem> inventory = new List<InventoryItem>(12);

    Vector3 mini;
    Vector3 max;
    private Dictionary<ItemData, InventoryItem> itemDictionary = new Dictionary<ItemData, InventoryItem>();

    private void OnEnable() {
        PortraitPiece.OnPieceCollected += Add;
    }
    private void OnDisable() {
        PortraitPiece.OnPieceCollected -= Add;
    }
    public void Add(ItemData itemData) {
        if(itemDictionary.TryGetValue((itemData), out InventoryItem item)) {
            return;
        }
        else {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Add(newItem);
            itemDictionary.Add(itemData, newItem);
            Debug.Log($"Added {itemData.displayName} to the inventory");
            OnInventoryChange?.Invoke(inventory);
        }
    }
    public void Remove(ItemData itemData) {
        if(itemDictionary.TryGetValue((itemData), out InventoryItem item)) {
            InventoryItem newItem = new InventoryItem(itemData);
            inventory.Remove(newItem);
            itemDictionary.Remove(itemData);
            OnInventoryChange?.Invoke(inventory);
        }
        else 
        {
            

        }
    }

   


}

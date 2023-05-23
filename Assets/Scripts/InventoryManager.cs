using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(12);
    private bool minimized;
    Vector3 mini;
    Vector3 max;


    private void Start() {
        mini = new Vector3(0,0,0);
        max = new Vector3(1,1,1);
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.I)) {
            if(!minimized) {
                minimized = true;
            }
            else {
                minimized = false;
            }
        }
        if(minimized) {
            gameObject.GetComponent<RectTransform>().localScale = mini;
        }
        if(!minimized) {
            gameObject.GetComponent<RectTransform>().localScale = max;
        }


    }

    private void OnEnable()
    {
        inventorySlots.Capacity = 12;
        Inventory.OnInventoryChange += DrawInventory;
    }
    private void OnDisable()
    {
        Inventory.OnInventoryChange -= DrawInventory;
    }
    void ResetInventory() {
        foreach (Transform childTransform in transform)
        {
            Destroy(childTransform.gameObject);
        }
        inventorySlots = new List<InventorySlot>(12);
    }
    void DrawInventory(List<InventoryItem> inventory)
    {
        ResetInventory();
        for ( int i = 0; i < inventorySlots.Capacity; i++) {
            CreateInventorySlot();
        }
        for ( int i = 0; i < inventorySlots.Count; i++) {
            if( i >= inventory.Count) {
                  inventorySlots[i].DrawSlot(null);
            }
            else { 
            inventorySlots[i].DrawSlot(inventory[i]);
            }
        }
    }
    void CreateInventorySlot(){
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);
        InventorySlot newSlotComponent = newSlot.GetComponent<InventorySlot>();
        inventorySlots.Add(newSlotComponent);
    }
}

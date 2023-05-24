using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Minimenu : MonoBehaviour
{
    // Start is called before the first frame update
    Button combine;
    Button inspect;
    public InventorySlot selected;
    void Awake()
    {
        inspect = gameObject.transform.Find("Inspect").GetComponent<Button>();
        combine = gameObject.transform.Find("Combine").GetComponent<Button>();
        combine.onClick.AddListener(Combine);
        inspect.onClick.AddListener(Inspect);
    }
    void Combine() {
        if(!InventorySlot.isCombining){
        InventorySlot.isCombining = true;
        } else {
            InventorySlot.isCombining = false;
        }
    }
    void Inspect() {
        selected = InventorySlot.selectedSlots[0]; // can get through parent
        GameObject slot = transform.parent.gameObject;
        InventoryManager invManager =slot.GetComponentInParent<InventoryManager>();
        
        int index = invManager.inventorySlots.IndexOf(selected);
        if(index >= Inventory.inventory.Count){
            Debug.Log("We empty");
            return;
        }
        Debug.Log(Inventory.inventory[index].inspectText);
        //TBD
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryPane : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textComponent.text = "Inventory: " + inventoryString();
    }

    private string inventoryString(){

        string inv = "";
        foreach (string item in GameManager.instance.Inventory){

            inv = inv +  " <br> " + item;
        }
        return inv;
    }
}

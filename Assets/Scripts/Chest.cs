using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Interactable
{
    public Sprite emptyChest;
    public string item = "";


    protected override void Interact() {

        if(!activated) {

             if(Input.GetKeyDown(key)){
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                if(item.Length > 0) {
                    GameManager.instance.ShowText("You recieved a " +item + "!",25,Color.yellow,transform.position, Vector3.up *50,3f);
                    GameManager.instance.Inventory.Add(item);
                    item = "";
                }
                
             }
            
        }
        base.Interact();

    }


    /*
    protected override void OnCollect(){

        if(!collected) {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ShowText("+" + pesosAmount + "pesos!",25,Color.yellow,transform.position, Vector3.up *50,3f);
            Debug.Log("Grant Money!");
        }
        base.OnCollect();
        if(collected) {
            Debug.Log("Money Taken");
        }
       
    }
    */
}

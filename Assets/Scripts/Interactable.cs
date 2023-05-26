using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Collidable
{
    public bool activated;
    public GameObject DialogueBox;
    public string FlavorText;
    public string denialText;
    public ItemData requiredItem;
    public AudioSource successEffect;
    public bool turnOff = false;
    public KeyCode key = KeyCode.E;
    public Sprite activatedImage;
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player"){
            Interact();
        }
    }

    protected virtual void Interact()   
    {

        if(!activated)
            GameManager.instance.ShowText("" + key,25,Color.red,transform.position, Vector3.zero,.01f);

        if(Input.GetKeyDown(key)){
            if(activated == false) {
                InventoryItem invRequired = null;
                if(requiredItem != null) {
                    invRequired = new InventoryItem(requiredItem);
                }
            bool containsItem = false;
            if(requiredItem != null ) {
            foreach(InventoryItem item in Inventory.inventory)
                {
                    if(requiredItem.displayName ==  item.itemData.displayName)
                    {
                        containsItem = true;
                    }
                }
            }
            if(!containsItem){
                DisplayText(denialText);
                return;
            }
            DisplayText(FlavorText);
            if(activatedImage != null) {
                successEffect.Play();
                GetComponent<SpriteRenderer>().sprite = activatedImage;
            }
            activated = true;
            
            Debug.Log("Huzzah!");
            } else if (activated == true && turnOff){
                activated = false;

            }

        }
    }
    protected virtual void DisplayText(string selectedText){

        if(selectedText.Length > 0)
            {
                string[] diaText;
                diaText = DialogueBox.GetComponent<Dialogue>().lines;
                diaText[0] = selectedText;
                DialogueBox.SetActive(true);
            }

    }
}

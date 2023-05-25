using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteractable : Interactable
{

    public bool puzzleBeaten;
    // Start is called before the first frame update
    public Sprite finishedPortrait;
    // Update is called once per frame


    public void Interact2() {

        Interact();
    }
    protected override void Interact()   
    {

        

        if(Input.GetKeyDown(key)){
            if(activated == false) {
            InventoryItem invRequired = new InventoryItem(requiredItem);
            if(!Inventory.inventory.Contains(invRequired)){
                DisplayText(denialText);
                return;
            }
            if(!puzzleBeaten) {
                DisplayText("The portrait fits in, but i'ts still too dark to see.");
                activated = true;
                GetComponent<SpriteRenderer>().sprite = finishedPortrait;
            }
            if(puzzleBeaten) {
                DisplayText(FlavorText);
                activated = true;
                GetComponent<SpriteRenderer>().sprite = finishedPortrait;
            }
            
            
            
            Debug.Log("Huzzah!");
            } else if (activated == true){
                activated = false;

            }

        }
    }
}

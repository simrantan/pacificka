using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInteractable : Interactable
{

    public bool puzzleBeaten;
    // Start is called before the first frame update

    // Update is called once per frame


    public void Interact2() {

        Interact();
    }
    protected override void Interact()   
    {

        

        if(Input.GetKeyDown(key)){
            if(activated == false) {
            
            if(!GameManager.instance.Inventory.Contains(requiredItem)){
                DisplayText(denialText);
                return;
            }
            if(puzzleBeaten) {
                DisplayText(FlavorText);
                activated = true;
            }
            
            
            
            Debug.Log("Huzzah!");
            } else if (activated == true){
                activated = false;

            }

        }
    }
}

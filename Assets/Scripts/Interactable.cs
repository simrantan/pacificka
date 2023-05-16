using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Collidable
{
    public bool activated;
    public GameObject DialogueBox;
    public string FlavorText;
    public string denialText;
    public string requiredItem;
    
    public KeyCode key = KeyCode.E;
    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player"){
            Interact();
        }
    }

    protected virtual void Interact()   
    {

        if(!activated)
            GameManager.instance.ShowText("" + key,25,Color.green,transform.position, Vector3.zero,.01f);

        if(Input.GetKeyDown(key)){
            if(activated == false) {
            
            if(!GameManager.instance.Inventory.Contains(requiredItem)){
                DisplayText(denialText);
                return;
            }
            DisplayText(FlavorText);
            activated = true;
            
            Debug.Log("Huzzah!");
            } else if (activated == true){
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

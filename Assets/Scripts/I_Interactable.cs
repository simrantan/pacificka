using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_Interactable : Interactable
{
    // Start is called before the first frame update
    public GameObject interactImagePrefab;
    public GameObject canvas;

    void Awake(){
        canvas = GameObject.FindWithTag("Canvas");
    }
  protected override void Interact() {
        GameObject slideshow;
        if(!activated) {

             if(Input.GetKeyDown(key)){
             slideshow = Instantiate(interactImagePrefab);
             slideshow.transform.SetParent(canvas.transform,false);
             }
            
        }
        


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Prompt : MonoBehaviour
{
   public bool active;
   public GameObject go;
   public TextMeshProUGUI txt;
   public Vector3 motion;
   public float period;
    bool alternate;
   public float lastShown;

    
    // Start is called before the first frame update
    void Start()
    {
        Show();
    }


    public void Show(){
        motion = Vector3.up;
         alternate = true;
    active = true;
    go.SetActive(active);
    go.transform.position = Camera.main.WorldToScreenPoint(gameObject.transform.position);

    }

    public void Hide(){
    active = false;
    go.SetActive(active);

   }
    // Update is called once per frame
    void Update()
    {

         if(!active)
        return;

        if(Time.time - lastShown > period)
        {
            if(!alternate) {
                alternate = true;
            }
            else if( alternate) {
                alternate = false;
            }
            
            lastShown = Time.time;
            Debug.Log("switching" + (Time.time - lastShown > period));
        }
        if(alternate){
            go.transform.position += motion * Time.deltaTime * 60;
        }
        else{
             go.transform.position -= motion * Time.deltaTime * 60;
        }
        
    }
    
}

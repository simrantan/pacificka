using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch_Puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> interactables;
    bool beaten = false;
    
    public GameObject painting;
    void Start()
    {
        foreach( Transform child in transform)
        {
            interactables.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(beaten == false)
        {
            foreach( GameObject interactable in interactables)
            {
                bool active = interactable.GetComponent<Torch>().activated;
                if(!active){
                    return;
                }
            }
            Debug.Log("Puzzle Beaten!");
            painting.GetComponent<PuzzleInteractable>().puzzleBeaten = true;
            GameManager.instance.ShowText("You beat the puzzle!",25,Color.yellow,transform.position, Vector3.up *50,3f);
        }
        
        
        beaten = true;
    }
}

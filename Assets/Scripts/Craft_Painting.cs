using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craft_Painting : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> portraitPieces;
    void Start()
    {
        portraitPieces.Add("Portrait Piece 1");
        portraitPieces.Add("Portrait Piece 2");
        portraitPieces.Add("Portrait Piece 3");
        portraitPieces.Add("Portrait Piece 4");

    }

    // Update is called once per frame
    void Update()
    {
        CheckInventory();
    }
    void CheckInventory(){
        foreach (string portraitPiece in portraitPieces) {
            if(!GameManager.instance.Inventory.Contains(portraitPiece)){
                return;
            }
        }
        GameManager.instance.Inventory.Add("Finished Portrait");
        foreach (string portraitPiece in portraitPieces) {
            GameManager.instance.ShowText("The pieces fit together, forming a Portrait",25,Color.blue,GameManager.instance.player.transform.position, Vector3.up *50,3f);
            GameManager.instance.Inventory.Remove(portraitPiece);
        }
    }
}

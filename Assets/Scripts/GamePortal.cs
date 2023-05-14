using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePortal : Collidable
{
    
    public string[] sceneNames;
    // Start is called before the first frame update
    protected override void OnCollide(Collider2D coll){
        // Teleport the player
        if(coll.name == "Player"){
            GameManager.instance.SaveState();
        string sceneName = sceneNames[Random.Range(0,sceneNames.Length)];
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}

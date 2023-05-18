using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    // Start is called before the first frame update

    public bool typing = true;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            if(textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
        if(lines[index].Length == 0) {
            gameObject.SetActive(false);
            typing = false;
        }
    }
    void OnEnable(){
        typing = true;
        textComponent.text = string.Empty;
        for (int i = 0; i < lines.Length; i++){
            if(lines[i].Length > 185) {
                string bookend = lines[i].Substring(185, lines[i].Length-185);
                if(i == lines.Length-1) {
                    Array.Resize<string>(ref lines, lines.Length + 1);
                }
                lines[i+1] = bookend + lines[i+1];
                lines[i] = lines[i].Substring(0,185);

            }
        }
        StartDialogue();
    }
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // create Dialogue text character by character
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);

        }
    }
    void NextLine()
    {
        if( index < lines.Length -1 && lines[index].Length > 0)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            
            gameObject.SetActive(false);
            for (int i = 0; i < lines.Length; i++){
            lines[i]= "";
            }
            index = 0;
            typing = false;
            Array.Resize<string>(ref lines, 1);
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    public string displayName;
    public string inspectText;
    public string[] combinesWith;
    public bool combine;
    public bool inspect;
    public Sprite icon;
    public Sprite inspectImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

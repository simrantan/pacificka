using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortraitPiece : Collectable
{
    // Start is called before the first frame update'

    public static event HandlePieceCollected OnPieceCollected;
    public delegate void HandlePieceCollected(ItemData itemData);
    public ItemData portraitData;

    protected override void OnCollect() {
        if(collected == false) {
        OnPieceCollected?.Invoke(portraitData);
        base.OnCollect();
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellDropzone : Dropzone
{
    protected override bool Resolve()
    {
        if(draggedCardVariable.Card.Basic) return false; // check if it's not Basic

        Debug.Log("Dropzone: Selling card for " + draggedCardVariable.Card.Gold + " Gold");

        draggedCardVariable.Card.Resolve(false); // resolving sell effect
        return true;
        
    }
}

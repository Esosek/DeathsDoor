using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellDropzone : Dropzone
{
    [SerializeField] private IntVariable goldVariable;
    protected override bool Resolve()
    {
        if(draggedCardVariable.Card.Basic) return false; // check if it's not Basic

        Debug.Log("Dropzone: Selling card for " + draggedCardVariable.Card.Gold + " Gold");

        // resolve sell effects
        goldVariable.SetValue(draggedCardVariable.Card.Gold + goldVariable.Value); // gain gold
        return true;
        
    }
}

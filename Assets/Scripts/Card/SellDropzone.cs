using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellDropzone : Dropzone
{
    [SerializeField] private Animator goldAnim;
    protected override bool Resolve()
    {
        if(draggedCardVariable.Card.Basic) return false; // check if it's not Basic

        Debug.Log("Dropzone: Selling card for " + draggedCardVariable.Card.Gold + " Gold");

        draggedCardVariable.Card.Resolve(false); // resolving sell effect
        goldAnim.SetTrigger("onGain");
        AudioManager.instance.Play("Card Sold");

        if(tutorialStepVariable.Value == 6) tutorialStepVariable.SetValue(tutorialStepVariable.Value + 1);

        return true;
        
    }
}

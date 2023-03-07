using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Draw", menuName = "Card Effect/Draw")]
public class Draw : Effect 
{
    [SerializeField] private Deck deck;
    [SerializeField] private Hand hand;

    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(isPlayed)
        {
            for (int i = 0; i < Value; i++)
            {
                hand.AddCard(deck.DrawCard()[0]);
            }
        }
    }
}

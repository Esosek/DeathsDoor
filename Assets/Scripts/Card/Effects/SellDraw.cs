using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Sell Draw", menuName = "Card Effect/Sell Draw")]
public class SellDraw : Effect 
{
    [SerializeField] private Deck deck;
    [SerializeField] private Hand hand;
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(!isPlayed)
        {
            for (int i = 0; i < Value; i++)
            {
                hand.AddCard(deck.DrawCard()[0]);
            }
        }
    }
}

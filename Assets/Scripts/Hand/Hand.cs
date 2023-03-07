using UnityEngine;
using System.Collections.Generic;
using System.Collections;

[CreateAssetMenu(fileName = "Hand", menuName = "Hand")]
public class Hand : ScriptableObject 
{
    public List<Card> Cards
    {
        get { return cards; }
        private set { cards = value; }
    }

    public int MaxHandSize
    {
        get { return maxHandSize; }
        private set { maxHandSize = value; }
    }

    [SerializeField] private List<Card> cards = new List<Card>(); // cards in Hand
    [SerializeField] private int maxHandSize = 6;
    [SerializeField] private GameEvent onHandDiscardedEvent;    
    [SerializeField] private GameEvent onCardDrawEvent;    
    public CardGenerator cardGen;
   
    public void AddCard(Card card) // GameManager or certain effects calls this when card is drawn
    {
        if(card == null) Debug.Log("What?");
        Debug.Log("Hand: Adding " + card.name + " to Hand");

        Cards.Add(card);
        onCardDrawEvent.Raise();
    }

    public void RemoveCard(int index) // to keep track of played or sold cards
    {
        Debug.Log("Hand: Removing card with index " + index + " from Hand");

        Cards.RemoveAt(index);
    }

    public List<Card> DiscardHand()
    {
        Debug.Log("Hand: Discarding Hand");
        List<Card> _discardedCards = new List<Card>(Cards); // store current cards in hands
        Cards.Clear();
        onHandDiscardedEvent.Raise();
        return _discardedCards; // return all cards that were discarded
    }
    
    public void ClearHand()
    {
        Debug.Log("Hand: Clearing Hand");
        Cards.Clear();
        onHandDiscardedEvent.Raise();
    }
}

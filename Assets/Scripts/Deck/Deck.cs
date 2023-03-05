using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Deck", menuName = "Deck")]
public class Deck : ScriptableObject 
{
    [SerializeField] private List<Card> initialDeck = new List<Card>(); // starting deck consists of 3 + 3 basic cards
    [SerializeField] private List<Card> fullDeck = new List<Card>(); // this is your current Deck with all cards acquired
    [SerializeField] private List<Card> currentDeck = new List<Card>(); // this changed realtime by drawing cards
    //[SerializeField] private Hand hand; // played cards are tracked on Hand
   
    public void NewRun()
    {
        fullDeck = new List<Card>(initialDeck);
        ResetToFull();
    }

    public void ResetToFull()
    {
        currentDeck = new List<Card>(fullDeck);
    }

    private void ShuffleDeck()
    {

    }
}

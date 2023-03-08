using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Deck", menuName = "Deck")]
public class Deck : ScriptableObject 
{
    public List<Card> Cards
    {
        get { return currentDeck; }
        private set { currentDeck = value; }
    }

    [SerializeField] private List<Card> initialDeck = new List<Card>(); // starting deck consists of 3 + 3 basic cards
    [SerializeField] private List<Card> fullDeck = new List<Card>(); // this is your current Deck with all cards acquired
    [SerializeField] private List<Card> currentDeck = new List<Card>(); // this changed realtime by drawing cards
    [SerializeField] private List<Card> playedCards = new List<Card>(); // tracks what cards were played to reshuffle them in when needed
    [SerializeField] private GameEvent onDeckChangedEvent;
    [SerializeField] Hand hand;
   
    public void NewRun()
    {
        Debug.Log("DECK: Restoring deck to default");

        fullDeck = new List<Card>(initialDeck); // reset full deck
        playedCards.Clear();
        ResetToFull();
    }

    public void ResetToFull()
    {
        Debug.Log("DECK: Reseting Deck to full - including bought cards");

        currentDeck = new List<Card>(fullDeck); // reset current deck
        playedCards.Clear();
        ShuffleDeck();
        onDeckChangedEvent.Raise();
    }

    public List<Card> DrawCard(int quantity = 1)
    {
        Debug.Log("DECK: Drawing " + quantity + " cards");
        
        List<Card> _cardsToDraw = new List<Card>();

        for (int i = 0; i < quantity; i++)
        {
            if(Cards.Count == 0) // you ran out of Deck
            {
                MovePlayedCardsToDeck(); // move played cards to Deck
                ShuffleDeck(); // shuffle it
            }

            if(hand.Cards.Count >= hand.MaxHandSize) break; // prevent over draw
            _cardsToDraw.Add(Cards[0]); // add top card to list that is returned as drawn cards
            currentDeck.RemoveAt(0); // and remove it from current deck
        }

        return _cardsToDraw;
    }

    public void AddCard(Card newCard) // call this method when buying or drafting cards
    {
        Debug.Log("DECK: Adding new card to Deck");
        fullDeck.Add(newCard); 
        currentDeck.Add(newCard); // to visually represent that it was addded to your deck
        onDeckChangedEvent.Raise();
    }

    public void TrackPlayedCard(Card newCard) // call this method when playing a card
    {
        Debug.Log("DECK: Tracked that card was played");
        playedCards.Add(newCard);
    }

    private void ShuffleDeck()
    {
        Debug.Log("DECK: Shuffling Deck");

        for (int i = 0; i < Cards.Count; i++)
        {
            Card _currentCard = Cards[i]; // store active shuffle card
            int _randomIndex = Random.Range(i, Cards.Count); // get random index somewhere next from our current Card
            Cards[i] = Cards[_randomIndex]; // swap current card with random card from next
            Cards[_randomIndex] = _currentCard;
        }
    }
    private void MovePlayedCardsToDeck()
    {
        Debug.Log("DECK: Moving all played cards to Deck");
        currentDeck = new List<Card>(playedCards); // put all played cards to current deck
        playedCards.Clear(); // clear played cards tracker
    }
}

using System.Collections.Generic;
using UnityEngine;

// Visually reflects Hand object
// Use of event hooks for UI updates
public class HandDisplay : MonoBehaviour
{
    [SerializeField] private Hand hand;
    [SerializeField] private IntVariable draggedCardIndex;
    [SerializeField] private GameObject cardPrefab; // for generating cards
    [SerializeField] private GameObject basicCardPrefab; // basic card prefab
    [SerializeField] private List<Card> cards = new List<Card>(); // internal track of cards for calculating differences

    public void UpdateUI() // is called OnCardPlayed and OnCardDraw event
    {
        int _handCountDif = hand.Cards.Count - cards.Count; // by how many cards Hand was changed since last update

        if(_handCountDif == 0) return; // no change was done, ends code

        if(_handCountDif < 0) // handles when card is played
        {
            CardPlayedUpdate();
            return; // code ends here
        } 

        CardDrawn(_handCountDif);
    }

    public void ClearHand() // is called OnHandDiscarded event
    {
        // destroy every Card object in hand
        for (int i = 0; i < cards.Count; i++)
        {
            Destroy(this.transform.GetChild(i).gameObject);
        }

        cards.Clear(); // clears internal memory of cards
    }    

    private void CardPlayedUpdate() // handles visual update when card was played
    {
        Debug.Log("Hand Display: Removing card from visual Hand");

        cards.RemoveAt(draggedCardIndex.Value); // removes the card from internal memory
        Destroy(this.transform.GetChild(draggedCardIndex.Value).gameObject); // destroy it's gameObject
    }

    private void CardDrawn(int handCountDif)
    {
        for (int i = 0; i < handCountDif; i++) // handles when card is drawn
        {
            Card _newCard = hand.Cards[cards.Count]; // get reference of drawn card directly from Hand

            GameObject _newCardObject;

            if(_newCard.Basic) _newCardObject = Instantiate(basicCardPrefab, this.transform);
            else _newCardObject = Instantiate(cardPrefab, this.transform); // creates new visual object in hand and stores a reference
            _newCardObject.GetComponent<CardDisplay>().SetCard(_newCard); // fills visual object with data from Hand
            cards.Add(_newCard); // stores in internal memory for difference count
        }
    }
}
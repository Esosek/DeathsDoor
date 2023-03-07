using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int upkeepDrawCount = 5;
    [SerializeField] private Deck deck;
    [SerializeField] private Hand hand;
    [SerializeField] private IntVariable goldVariable;
    [SerializeField] private GameEvent onGameResetEvent;
    
    private void Start()
    {
        NewRun();
    }

    public void NewRun()
    {
        deck.NewRun();
        hand.ClearHand();
        goldVariable.SetValue(0);
        onGameResetEvent.Raise();
    }
    public void DraftPhase()
    {

    }

    public void NewFight() // is called OnFightStart and OnDraftEnd event
    {
        deck.ResetToFull();
        hand.ClearHand();
        goldVariable.SetValue(0); // reset Gold to prevent boosting the shop
        Upkeep();
    }

    public void Upkeep() // is called from NewFight() and OnCombatResolved event
    {
        List<Card> _discardedCards = new List<Card>(hand.DiscardHand()); // fist discard all cards from previous turn

        foreach (var card in _discardedCards) // track them in Deck for reshuffling
        {
            deck.TrackPlayedCard(card);
        }

        List<Card> _drawnCards = new List<Card>(deck.DrawCard(upkeepDrawCount)); // get upkeepDrawCount cards from Deck

        foreach (var card in _drawnCards) // push it to Hand
        {
            hand.AddCard(card);
        }
    }
}

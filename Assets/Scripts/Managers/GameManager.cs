using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake() => instance = this;

    [SerializeField] private int upkeepDrawCount = 5;
    [SerializeField] private Deck deck;
    [SerializeField] private Hand hand;
    [SerializeField] private IntVariable goldVariable;
    [SerializeField] private GameEvent onGameResetEvent;
    [SerializeField] private IntVariable killCountVariable;
    [SerializeField] private EnemyGenerator enemyGen;
    [SerializeField] private Character hero;
    [SerializeField] private GameObject gameBlock;
    
    private void Start()
    {
        NewRun();
    }

    public void NewRun()
    {
        gameBlock.SetActive(false);
        hero.Reset();
        enemyGen.ResetEnemy();
        killCountVariable.SetValue(0); // reset kill count
        deck.NewRun();
        hand.ClearHand();
        goldVariable.SetValue(0);
        onGameResetEvent.Raise();
    }

    public void NewFight() // is called OnFightStart event
    {
        deck.ResetToFull();
        hand.ClearHand();
        goldVariable.SetValue(0); // reset Gold to prevent boosting the shop
        enemyGen.GenerateEnemy();
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
    
    public void OnFightEnd() // is called OnEnemyDied
    {
        deck.ResetToFull();
    }

    public void OnHeroDied() // is called OnHeroDied
    {
        gameBlock.SetActive(true);
    }
}

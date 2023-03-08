using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DraftManager : MonoBehaviour
{
    public static DraftManager instance;

    [SerializeField] private int draftRounds = 4; // how many rounds draft have
    [SerializeField] private int offerCount = 3; // how many cards are offered each round
    [SerializeField] private TextMeshProUGUI currentRoundText;
    [SerializeField] private CardGenerator cardGen;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private Transform offerParent;
    [SerializeField] private Deck deck;
    [SerializeField] private Hand hand;
    [SerializeField] private GameEvent onDraftEndEvent;

    private List<GameObject> offeredCardObjects = new List<GameObject>(); // track offered card objects for clear purposes

    private void Awake() => instance = this;

    private int currentRound = 1; // 1-4

    public void StartDraft() // is called OnGameReset event
    {
        // hand and deck clearing happens in GameManager
        
        ClearOfferedCards();
        currentRound = 1;
        SetRoundText();
        OfferCards();
    }

    public void NextRound()
    {
        ClearOfferedCards();
        currentRound++;
        SetRoundText();
        OfferCards();
    }

    public void PickCard(Card pickedCard)
    {
        deck.AddCard(pickedCard);
        hand.AddCard(pickedCard); // visualize drafted cards in hand

        if(currentRound == 4)
        {
            /*for (int i = 0; i < offerParent.childCount; i++) // clear hand
            {
                Destroy(offerParent.GetChild(0));
            }*/
            hand.ClearHand();

            onDraftEndEvent.Raise(); // draft ends
        } 
        else NextRound();
    }

    private void SetRoundText()
    {
        currentRoundText.text = "Pick " + currentRound + " of " + draftRounds;
    }

    private void OfferCards()
    {
        for (int i = 0; i < offerCount; i++) // create as many cards as configured as offerCount
        {
            Card _newCard = cardGen.GenerateCard();
            GameObject _newCardObject = Instantiate(cardPrefab, offerParent);
            _newCardObject.GetComponent<CardDisplay>().SetCard(_newCard);
            _newCardObject.GetComponent<DraftCard>().SetCard(_newCard);
            offeredCardObjects.Add(_newCardObject); // track GameObjects for clear
        }
    }    

    private void ClearOfferedCards()
    {
        foreach (var cardObject in offeredCardObjects)
        {
            Destroy(cardObject);
        }

        offeredCardObjects.Clear();
    }
}

using UnityEngine;
using TMPro;

public class DeckDisplay : MonoBehaviour
{
    [SerializeField] private Deck deck;
    [SerializeField] private TextMeshProUGUI deckCounter;
    public void UpdateUI() // is called OnDeckChanged event
    {
        deckCounter.text = deck.Cards.Count.ToString();
    }
}

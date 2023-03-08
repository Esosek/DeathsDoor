using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopCard : MonoBehaviour
{
    [SerializeField] private GameObject costIcon;
    [SerializeField] private GameObject soldIcon;
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private Color32 unbuyableColor;
    [SerializeField] private Deck deck;
    [SerializeField] private IntVariable goldVariable;
    [SerializeField] GameEvent onCardBoughtEvent;

    private Card assignedCard;

    public void SetCard(Card card)
    {
        assignedCard = card;
        costText.text = assignedCard.BuyCost.ToString();
        UpdateShopCard(); // if offer is unaffordable
    }

    public void OnBuy() // is called on a single instance when card is bought
    {
        if(goldVariable.Value < assignedCard.BuyCost) return; // you can't afford it

        deck.AddCard(assignedCard);
        costIcon.SetActive(false);
        soldIcon.SetActive(true);
        goldVariable.SetValue(goldVariable.Value - assignedCard.BuyCost);
        onCardBoughtEvent.Raise();
    }

    public void UpdateShopCard() // is called for each instance OnCardBought event
    {
        if(assignedCard.BuyCost <= goldVariable.Value) return; // no change needed

        costIcon.GetComponent<Image>().color = unbuyableColor;
        costIcon.GetComponent<Button>().interactable = false;
    }
}

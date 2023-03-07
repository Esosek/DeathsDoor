using UnityEngine;
using System.Collections;

public class SellRandomCardMono : MonoBehaviour
{
    [SerializeField] private Hand hand;
    [SerializeField] private Transform handDisplay;
    public void Proc() // is called OnRandomCardSold
    {
        StartCoroutine(Sell());
    }

    private IEnumerator Sell()
    {
        yield return new WaitForSeconds(0.2f);

        if(hand.Cards.Count != 0)
        {
            int _cardIndex = Random.Range(0, hand.Cards.Count);
            hand.Cards[_cardIndex].Resolve(false);
            hand.RemoveCard(_cardIndex);
            Destroy(handDisplay.GetChild(_cardIndex).gameObject);
        }        
    }
}

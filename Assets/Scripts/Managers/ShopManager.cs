using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private int offerCount = 6; // number of offers you make
    [SerializeField] private Transform offerParent; // instantiate offers here
    [SerializeField] private GameObject shopCardPrefab;
    [SerializeField] private CardGenerator cardGen;

    private List<GameObject> offerObjects = new List<GameObject>(); // for tracking instantiated objects -> clear

    public void OpenShop() // is called OnEnemyDied event
    {
        MakeOffers();
    }

    public void ClearOffers() // is called OnShopClosed
    {
        foreach (var offerObject in offerObjects)
        {
            Destroy(offerObject);
        }

        offerObjects.Clear();
    }

    private void MakeOffers()
    {
        for (int i = 0; i < offerCount; i++)
        {
            GameObject _newCardObject = Instantiate(shopCardPrefab, offerParent); // instantiate ShopCard template
            offerObjects.Add(_newCardObject); // track object for clear purposes

            Card _newCard = cardGen.GenerateCard(); // generate new card
            _newCardObject.GetComponentInChildren<CardDisplay>().SetCard(_newCard); // set display Card
            _newCardObject.GetComponent<ShopCard>().SetCard(_newCard); // set ShopCard
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")] // to create Basic cards, it's not used otherwise
public class Card : ScriptableObject 
{
    public List<Sprite> Art
    {
        get { return cardArt; }
        private set { cardArt = value; }
    }

    public bool Basic
    {
        get { return basic; }
        private set { basic = value; }
    }
    
    public int BuyCost
    {
        get { return buyCost; }
        private set { buyCost = value; }
    }

    public int Gold
    {
        get { return gold; }
        private set { gold = value; }
    }

    public List<Effect> Effects
    {
        get { return effects; }
        private set { effects = value; }
    }

    [SerializeField] private bool basic = false; // to mark Basic cards because they are naturally unsellable
    [SerializeField] private List<Sprite> cardArt = new List<Sprite>(); // icons of effects = card art
    [SerializeField] private int buyCost;
    [SerializeField] private int gold;
    [SerializeField] private List<Effect> effects = new List<Effect>();

    public void SetCard(int goldValue, int buyCostValue, List<Effect> cardEffects, bool isBasic = false)
    {
        Gold = goldValue;
        BuyCost = buyCostValue;
        Basic = isBasic;

        foreach (var effect in cardEffects) // fetch card art from generated effects
        {
            cardArt.Add(effect.Art);
        }
    }

    public void Resolve()
    {
        Debug.Log("Card: Resolving effects");

        foreach (var effect in Effects)
        {
            effect.Resolve();
        }
    }

    private void OnEnable() {
        if(!Basic) return; // works for basic cards only
        effects[0].SetValue(effects[0].Value);
    }
}

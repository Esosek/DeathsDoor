using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardGen", menuName = "Card Generator")] // to create Basic cards, it's not used otherwise
public class CardGenerator : ScriptableObject
{
    [SerializeField] private List<Effect> primaryRollEffects = new List<Effect>();
    [SerializeField] private List<Effect> secondaryRollEffects = new List<Effect>();
    [SerializeField] private Card cardObject;
    [SerializeField] private IntVariable goldVariable;
    [SerializeField] private List<int> minCostValue = new List<int>();
    [SerializeField] private List<int> maxCostValue = new List<int>();
    [SerializeField] private List<int> minGoldValue = new List<int>();
    [SerializeField] private List<int> maxGoldValue = new List<int>();

    private int tier = 0; // 1 - 5 while last tier can be reached only in some effect combos
    private Effect primaryRoll;
    private Effect secondaryRoll;

    public Card GenerateCard()
    {
        Card _newCard = Instantiate(cardObject); // instantiate new card object which is returned after data fill
        GetCurrentTier();

        PrimaryRoll();
        SecondaryRoll();

        List<Effect> _rolledEffects = new List<Effect>();
        _rolledEffects.Add(primaryRoll);
        _rolledEffects.Add(secondaryRoll);

        _newCard.SetCard(RollGold(), RollCost(), _rolledEffects);
        return _newCard;
    }

    private void GetCurrentTier()
    {
        int _gold = goldVariable.Value;

        if(_gold < 10) tier = 0;
        else if(_gold >= 10 && _gold < 20) tier = 1;
        else if(_gold >= 20 && _gold < 30) tier = 2;
        else if(_gold >= 30 && _gold < 40) tier = 3;
        else if(_gold >= 40) tier = 4;
    }

    private int RollCost()
    {
        int _cost = Random.Range(minCostValue[tier], maxCostValue[tier]);
        return _cost;
    }

    private int RollGold()
    {
        int _gold = Random.Range(minGoldValue[tier], maxGoldValue[tier]);
        return _gold;
    }

    private void PrimaryRoll()
    {
        int _effectIndex = Random.Range(0, primaryRollEffects.Count); // get random index from all primary effects
        Effect _effect = primaryRollEffects[_effectIndex]; // store the effect
        primaryRoll = Instantiate(_effect); // internal store for secondary roll

        if(primaryRoll.MaxTierRolls.Count == 0) // check if value needs a roll
        {
            primaryRoll.SetValue(primaryRoll.MinTierRolls[tier]);
        }
        else // if yes, roll between min and max
        {
            int _valueRoll = Random.Range(primaryRoll.MinTierRolls[tier], primaryRoll.MaxTierRolls[tier]);
            primaryRoll.SetValue(_valueRoll);
        }
    }

    private void SecondaryRoll()
    {
        int _effectIndex = Random.Range(0, secondaryRollEffects.Count); // get random index from all primary effects
        Effect _effect = secondaryRollEffects[_effectIndex]; // store the effect
        secondaryRoll = Instantiate(_effect); // internal store for secondary roll

        if(secondaryRoll.MaxTierRolls.Count == 0) // check if value needs a roll
        {
            secondaryRoll.SetValue(primaryRoll.MinTierRolls[tier]);
        }
        else // if yes, roll between min and max
        {
            int _valueRoll = Random.Range(secondaryRoll.MinTierRolls[tier], secondaryRoll.MaxTierRolls[tier]);
            secondaryRoll.SetValue(_valueRoll);
        }
    }
}

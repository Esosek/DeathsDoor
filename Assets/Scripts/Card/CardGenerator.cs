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

    // references for special rules
    [SerializeField] private Effect extraGoldEffect;
    [SerializeField] private Effect spendGoldEffect;
    [SerializeField] private Effect spendHealthEffect;

    private int tier = 0; // 1 - 5 while last tier can be reached only in some effect combos
    private Effect primaryRoll;
    private Effect secondaryRoll;
    private Effect primaryEffectSource; // for consolidating duplicates
    private Card newCard;

    public Card GenerateCard()
    {
        newCard = Instantiate(cardObject); // instantiate new card object which is returned after data fill
        GetCurrentTier();

        int _gold = RollGold(); // roll it before a possible tier upgrade
        int _cost = RollCost(); // roll it before a possible tier upgrade

        PrimaryRoll();
        SecondaryRoll();

        List<Effect> _rolledEffects = new List<Effect>();
        _rolledEffects.Add(primaryRoll);
        _rolledEffects.Add(secondaryRoll);

        newCard.SetCard(_gold, _cost, _rolledEffects);
        return newCard;
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
        primaryEffectSource = primaryRollEffects[_effectIndex]; // store the effect

        primaryRoll = Instantiate(primaryEffectSource); // internal store for secondary roll

        if(primaryEffectSource == extraGoldEffect) { newCard.AddGold(RollValue(primaryRoll)); } // extra gold effect
        else primaryRoll.SetValue(RollValue(primaryRoll));
    }

    private void SecondaryRoll()
    {
        int _effectIndex;
        Effect _effect;

        if(primaryEffectSource.SecondRollPool.Count > 0) // has limited rules for second rules
        {
            _effectIndex = Random.Range(0, primaryEffectSource.SecondRollPool.Count); // get random index from all primary effects
            _effect = primaryEffectSource.SecondRollPool[_effectIndex]; // store the effect
            if(primaryEffectSource.SecondRollHigherTier) tier += 2; // some primary effects upgrades the tier
        }

        // if no limits are applied
        else 
        {
            _effectIndex = Random.Range(0, secondaryRollEffects.Count); // get random index from all primary effects
            _effect = secondaryRollEffects[_effectIndex]; // store the effect
        }        

        if(_effect == primaryEffectSource) // it's a duplicate of primary roll
        {
            Debug.Log("CardGen: Duplicate effect was generated");

            if(primaryEffectSource == extraGoldEffect) { newCard.AddGold(RollValue(primaryRoll)); } // extra gold effect

            primaryRoll.SetValue(RollValue(primaryRoll) + primaryRoll.Value);
            secondaryRoll = primaryRoll;
            return;
        }

        Effect _secondaryEffectSource = _effect; // for extra gold effect

        secondaryRoll = Instantiate(_effect); // internal store for secondary roll

        if(_secondaryEffectSource == extraGoldEffect) { newCard.AddGold(RollValue(secondaryRoll)); } // extra gold effect

        secondaryRoll.SetValue(RollValue(secondaryRoll));
    }

    private int RollValue(Effect roll)
    {
        int _valueRoll = 0;

        if(roll.MaxTierRolls.Count == 0) // check if value needs a roll
        {
            if(roll.MinTierRolls.Count <= tier) _valueRoll = 0;
            else _valueRoll = roll.MinTierRolls[tier];
        }
        else // if yes, roll between min and max
        {
            _valueRoll = Random.Range(roll.MinTierRolls[tier], roll.MaxTierRolls[tier]);
        }
        
        // check if the first roll is spender
        if(primaryEffectSource == spendGoldEffect || primaryEffectSource == spendHealthEffect)
        {
            _valueRoll  =  Mathf.RoundToInt(_valueRoll * 1.5f);
        }

        return _valueRoll;
    }
}

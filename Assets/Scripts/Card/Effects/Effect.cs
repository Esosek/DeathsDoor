using UnityEngine;
using System.Collections.Generic;

public abstract class Effect : ScriptableObject 
{
    public int Value
    {
        get { return effectValue; }
        private set { effectValue = value; }
    }

    public Sprite Art
    {
        get { return effectArt; }
        private set { effectArt = value; }
    }

    public string RuleText
    {
        get { return newRuleText; }
        private set { newRuleText = value; }
    }

    public List<int> MinTierRolls
    {
        get { return minTierRolls; }
        private set { minTierRolls = value; }
    }

    public List<int> MaxTierRolls
    {
        get { return maxTierRolls; }
        private set { maxTierRolls = value; }
    }

    public List<Effect> SecondRollPool
    {
        get { return secondRollPool; }
        private set { secondRollPool = value; }
    }

    public bool SecondRollHigherTier
    {
        get { return secondRollHigherTier; }
        private set { secondRollHigherTier = value; }
    }
    

    [SerializeField] private int effectValue;
    [SerializeField] private Sprite effectArt;
    [SerializeField] private string ruleText;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Character hero;
    [SerializeField] private List<int> minTierRolls = new List<int>();
    [SerializeField] private List<int> maxTierRolls = new List<int>();
    [SerializeField] private List<Effect> secondRollPool = new List<Effect>();
    [SerializeField] private bool secondRollHigherTier = false;
    protected Card card;

    private string newRuleText;

    public virtual void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        Debug.Log("Resolving " + this.name + " effect");
    }

    public void SetValue(int value)
    {
        Value = value;
    }

    public void StoreCardRef(Card cardRef)
    {
        card = cardRef;
    }

    public void SetRuleText()
    {
        // replaces value placeholder and set the current rule text
        RuleText = ruleText.Replace("<value>", Value.ToString());
    }
}

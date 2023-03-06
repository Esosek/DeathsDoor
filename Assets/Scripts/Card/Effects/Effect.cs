using UnityEngine;

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
        get { return ruleText; }
        private set { ruleText = value; }
    }

    [SerializeField] private int effectValue;
    [SerializeField] private Sprite effectArt;
    [SerializeField] private string ruleText;
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Character hero;

    public virtual void Resolve() // class to be overriden to execute specific behaviour
    {
        Debug.Log("Resolving " + this.name + " effect");
    }

    public void SetValue(int value)
    {
        Value = value;

        // replaces value placeholder and set the current rule text
        string _newRuleText = RuleText.Replace("<value>", Value.ToString());
        RuleText = _newRuleText;
    }
}

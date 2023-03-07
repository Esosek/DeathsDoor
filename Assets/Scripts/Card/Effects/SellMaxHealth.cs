using UnityEngine;

[CreateAssetMenu(fileName = "Sell Max Health", menuName = "Card Effect/Sell Max Health")]
public class SellMaxHealth : Effect 
{
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(!isPlayed) hero.AddMaxHealth(Value);
    }
}

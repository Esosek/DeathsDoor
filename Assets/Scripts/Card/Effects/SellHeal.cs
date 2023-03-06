using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Card Effect/Sell Heal")]
public class SellHeal : Effect 
{
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(!isPlayed) hero.Heal(Value);
    }
}

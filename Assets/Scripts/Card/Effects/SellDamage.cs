using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Card Effect/Sell Damage")]
public class SellDamage : Effect 
{
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(!isPlayed) enemy.TakeDamage(Value);
    }
}

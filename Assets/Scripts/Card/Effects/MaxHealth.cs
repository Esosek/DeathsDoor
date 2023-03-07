using UnityEngine;

[CreateAssetMenu(fileName = "Max Health", menuName = "Card Effect/Max Health")]
public class MaxHealth : Effect 
{
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(isPlayed) hero.AddMaxHealth(Value);
    }
}

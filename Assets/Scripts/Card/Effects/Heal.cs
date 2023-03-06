using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Card Effect/Heal")]
public class Heal : Effect 
{
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(isPlayed) hero.Heal(Value);
    }
}

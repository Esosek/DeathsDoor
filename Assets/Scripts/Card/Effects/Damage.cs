using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Card Effect/Damage")]
public class Damage : Effect 
{
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(isPlayed) enemy.TakeDamage(Value);
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "Damage", menuName = "Card Effect/Damage")]
public class Damage : Effect 
{
    public override void Resolve() // class to be overriden to execute specific behaviour
    {
        base.Resolve();
        
        enemy.TakeDamage(Value);
    }
}

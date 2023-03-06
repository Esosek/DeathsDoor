using UnityEngine;

[CreateAssetMenu(fileName = "Heal", menuName = "Card Effect/Heal")]
public class Heal : Effect 
{
    public override void Resolve() // class to be overriden to execute specific behaviour
    {
        base.Resolve();
        
        hero.Heal(Value);
    }
}

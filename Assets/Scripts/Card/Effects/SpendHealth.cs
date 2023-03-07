using UnityEngine;

[CreateAssetMenu(fileName = "Spend Health", menuName = "Card Effect/Spend Health")]
public class SpendHealth : Effect 
{
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(isPlayed) 
        {
            hero.TakeDamage(Value);
        }
    }
}

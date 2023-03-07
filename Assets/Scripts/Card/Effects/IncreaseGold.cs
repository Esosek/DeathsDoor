using UnityEngine;

[CreateAssetMenu(fileName = "Increase Gold", menuName = "Card Effect/Increase Gold")]
public class IncreaseGold : Effect
{    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(isPlayed) card.AddGold(Value);
    }
}

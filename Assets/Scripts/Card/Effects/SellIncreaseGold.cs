using UnityEngine;

[CreateAssetMenu(fileName = "Sell Increase Gold", menuName = "Card Effect/Sell Increase Gold")]
public class SellIncreaseGold : Effect
{
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(!isPlayed) card.AddGold(Value);
    }
}

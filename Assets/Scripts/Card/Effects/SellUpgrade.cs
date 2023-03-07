using UnityEngine;

[CreateAssetMenu(fileName = "Sell Upgrade", menuName = "Card Effect/Sell Upgrade")]
public class SellUpgrade : Effect
{
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(isPlayed) 
        {
            
        }
    }
}

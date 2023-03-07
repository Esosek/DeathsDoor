using UnityEngine;

[CreateAssetMenu(fileName = "Sell Upgrade", menuName = "Card Effect/Sell Upgrade")]
public class SellUpgrade : Effect
{
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(isPlayed) 
        {
            // since SellUpgrade have to be primary effect and CardGen limits outcomes of the secondary effect
            // you may simply add Value to the secondary effect *fingers crossed*

            card.Effects[1].SetValue(card.Effects[1].Value + Value);
        }
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "Sell Random Card", menuName = "Card Effect/Sell Random Card")]
public class SellRandomCard : Effect
{
    [SerializeField] private GameEvent OnRandomCardSoldEvent;
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(isPlayed) 
        {
            OnRandomCardSoldEvent.Raise();
        }
    }
}

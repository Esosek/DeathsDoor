using UnityEngine;

[CreateAssetMenu(fileName = "Gain Gold From Random", menuName = "Card Effect/Gain Gold From Random")]
public class GainGoldFromRandom : Effect
{
    [SerializeField] private Hand hand;
    [SerializeField] private IntVariable goldVariable;
    [SerializeField] private IntVariable draggedCardIndex;
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(isPlayed && hand.Cards.Count > 1) 
        {
            int _cardIndex = draggedCardIndex.Value;

            while (_cardIndex == draggedCardIndex.Value)
            {
                _cardIndex = Random.Range(0, hand.Cards.Count);                
            }
            goldVariable.SetValue(goldVariable.Value + hand.Cards[_cardIndex].Gold);
        }
    }
}

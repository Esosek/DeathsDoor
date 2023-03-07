using UnityEngine;

[CreateAssetMenu(fileName = "Spend Gold", menuName = "Card Effect/Spend Gold")]
public class SpendGold : Effect 
{
    [SerializeField] IntVariable goldVariable;
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
        
        if(isPlayed) 
        {
            goldVariable.SetValue(goldVariable.Value - Value);
        }
    }
}

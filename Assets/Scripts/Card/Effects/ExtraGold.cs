using UnityEngine;

[CreateAssetMenu(fileName = "Extra Gold", menuName = "Card Effect/Extra Gold")]
public class ExtraGold : Effect 
{
    public override void Resolve(bool isPlayed) // class to be overriden to execute specific behaviour
    {
        base.Resolve(isPlayed);
    }
}

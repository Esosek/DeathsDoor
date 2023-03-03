using UnityEngine;

[CreateAssetMenu(fileName = "New Int Variable", menuName = "Variables/Int")]
public class IntVariable : ScriptableObject
{
    public int Value
    {
        get { return currentValue; }
        private set { currentValue = value; }
    }
    [SerializeField] private int currentValue;
    [SerializeField] private GameEvent onChangeEvent;

    public void SetValue(int value)
    {
        Value = value;
        if(onChangeEvent != null) onChangeEvent.Raise();
    }
}

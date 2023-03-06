using UnityEngine;

[CreateAssetMenu(fileName = "New Card Variable", menuName = "Variables/Card")]
public class CardVariable : ScriptableObject
{
    public Card Card
    {
        get { return card; }
        private set { card = value; }
    }
    [SerializeField] private Card card;
    [SerializeField] private GameEvent onChangeEvent;

    public void SetCard(Card newCard)
    {
        Card = newCard;
        if(onChangeEvent != null) onChangeEvent.Raise();
    }
}
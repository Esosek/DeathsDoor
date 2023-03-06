using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler
{
    [SerializeField] private CardVariable draggedCardVariable; // used to read dragged card
    [SerializeField] private IntVariable draggedCardIndex; // used to read dragged card index
    [SerializeField] private Hand hand;
    [SerializeField] private Deck deck;
    [SerializeField] private GameEvent onCardPlayedEvent;

    public void OnDragStart() // is called OnCardDragStart event
    {
        // code to execute
        // possibly some visual feedback
    }

    public void OnDragEnd() // is called OnCardDragEnd and OnCardPlayed event
    {
        // code to execute
        // possibly some visual feedback
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Slot Targeting: Dropping card in dropzone");

        if(eventData.pointerDrag != null && draggedCardVariable.Card != null) // null check
        {
            Destroy(eventData.pointerDrag); // destroy visual object of dragged Card - not ideal place but easier approach
            deck.TrackPlayedCard(draggedCardVariable.Card); // track the card played
            draggedCardVariable.Card.Resolve(); // resolving effect itself
            draggedCardVariable.SetCard(null); // reset variable of dragged card 
            hand.RemoveCard(draggedCardIndex.Value); // remove the card from hand
            onCardPlayedEvent.Raise();
        }
    }
}
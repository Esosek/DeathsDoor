using UnityEngine;
using UnityEngine.EventSystems;

public class Dropzone : MonoBehaviour, IDropHandler
{
    [SerializeField] protected CardVariable draggedCardVariable; // used to read dragged card
    [SerializeField] private IntVariable draggedCardIndex; // used to read dragged card index
    [SerializeField] private Hand hand;
    [SerializeField] private Deck deck;
    [SerializeField] private GameEvent onDropEvent;

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
            if(!Resolve()) return; // if resolved did not happen return
            Destroy(eventData.pointerDrag); // destroy visual object of dragged Card - not ideal place but easier approach            
            draggedCardVariable.SetCard(null); // reset variable of dragged card 
            hand.RemoveCard(draggedCardIndex.Value); // remove the card from hand
            onDropEvent.Raise();
        }
    }

    protected virtual bool Resolve() // selling overrides default behaviour
    {
        deck.TrackPlayedCard(draggedCardVariable.Card); // track the card played
        draggedCardVariable.Card.Resolve(); // resolving effect itself
        return true;
    }
}
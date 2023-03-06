using UnityEngine;
using UnityEngine.EventSystems;

// Dragging card from Hand
public class CardDrag : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler 
{
    [SerializeField] private GameEvent onCardDragStart; // used to highlight possible targets for
    [SerializeField] private GameEvent onCardDragEnd; // used to turn off highlights
    [SerializeField] private CardVariable draggedCardVariable; // used to store what card is dragged
    [SerializeField] private IntVariable draggedCardIndex; // used to store dragged card hand index
    [SerializeField] private GameObject rayCastTarget; // for raycast unblocking while dragging
    [SerializeField] private Hand hand;

    private Card card;
    private Vector3 originalPos;
    private Animator anim;
    private GameObject placeholder;
    private Transform originalParent; // reference to hand parent used if not played

    private void Start() {
        anim = GetComponent<Animator>();
        originalParent = this.transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        card = GetComponent<CardDisplay>().Card; // store assigned Card reference
        draggedCardIndex.SetValue(this.transform.GetSiblingIndex()); // store hand index of dragged card
        originalPos = this.transform.position; // store original position -> will return to if not played
        Placeholder(); // creates placeholder in hand
        this.transform.SetParent(originalParent.parent); // unparents from hand so the card can move freely on screen
        rayCastTarget.SetActive(false); // disable raycast block
   
        draggedCardVariable.SetCard(card);// store variable of dragged card

        onCardDragStart.Raise(); // event raise for hooks
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = Input.mousePosition; // moves the card to mouse
    }


    // executes only if the dragged Card is suppose to return to hand
    // if the card is actually played this is not executed and the placeholder gets destroyed by HandDisplay
    public void OnEndDrag(PointerEventData eventData) 
    {
        this.transform.SetParent(originalParent); // returns this card under hand parent
        this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex()); // sets the correct position in children
        Destroy(placeholder); // destroys placeholder in hand
        rayCastTarget.SetActive(true); // enable raycast block
        this.transform.position = originalPos; // return to original relative position in world (is changing while dragging)
        anim.SetTrigger("onCardDragEnd"); // play OnCreate animation
        draggedCardVariable.SetCard(null); // reset variable of dragged card

        onCardDragEnd.Raise(); // event raise for hooks
    }

    private void Placeholder() // creates an empty object in hand
    {
        placeholder = new GameObject();
        placeholder.transform.SetParent(originalParent);
        placeholder.AddComponent<RectTransform>();
        placeholder.GetComponent<RectTransform>().sizeDelta = gameObject.GetComponent<RectTransform>().sizeDelta;
        placeholder.GetComponent<RectTransform>().localScale = gameObject.GetComponent<RectTransform>().localScale;
        placeholder.transform.SetSiblingIndex(transform.GetSiblingIndex());
    }
}
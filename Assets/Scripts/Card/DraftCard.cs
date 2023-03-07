using UnityEngine;

public class DraftCard : MonoBehaviour
{
    private DraftManager draftManager;
    private Card assignedCard;

    private void Start()
    {
        draftManager = DraftManager.instance;
    }

    public void SetCard(Card card) // is set from DraftManager when instantiated
    {
        assignedCard = card;
    }

    public void OnPick() // is called onClick
    {
        draftManager.PickCard(assignedCard);
    }
}

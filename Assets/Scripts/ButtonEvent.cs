using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    [SerializeField] private GameEvent onClickEvent;

    public void OnClick()
    {
        if(onClickEvent != null) onClickEvent.Raise();
    }
}

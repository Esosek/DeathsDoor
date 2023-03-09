using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public void Trigger(string onTriggerName) // is called on connected event
    {
        animator.SetTrigger(onTriggerName);
    }
}

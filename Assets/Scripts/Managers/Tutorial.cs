using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private IntVariable tutorialStepVariable;
    [SerializeField] private GameObject[] tutorialParts;

    void Start()
    {
        Advance();
    }

    public void Advance() // is called OnTutorialChanged
    {
        if(tutorialStepVariable.Value < tutorialParts.Length) tutorialParts[tutorialStepVariable.Value].SetActive(true);
        else { tutorialParts[tutorialParts.Length - 1].SetActive(false); return; }
        if(tutorialStepVariable.Value != 0) tutorialParts[tutorialStepVariable.Value - 1].SetActive(false);
    }
}

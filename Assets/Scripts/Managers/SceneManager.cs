using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private GameObject shopCanvas;
    [SerializeField] private GameObject endScreen;
    [SerializeField] private GameObject draftCanvas;
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject playerObject;

    public void ShowShop() // is called OnEnemyDied event
    {
        mainCanvas.SetActive(false);
        shopCanvas.SetActive(true);
    }

    public void ShowEndScreen() // is called OnHeroDied event
    {
        endScreen.SetActive(true);
        playerObject.SetActive(false);
    }

    public void ShowDraft() // is called OnGameReset event
    {
        draftCanvas.SetActive(true);
        endScreen.SetActive(false);
        mainCanvas.SetActive(false);
        playerObject.SetActive(true);
    }

    public void ShowMain() // is called OnShopClosed and OnDraftEnd events
    {
        mainCanvas.SetActive(true);
        shopCanvas.SetActive(false);
        draftCanvas.SetActive(false);
    }
}
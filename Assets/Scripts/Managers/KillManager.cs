using UnityEngine;
using TMPro;

public class KillManager : MonoBehaviour
{
    [SerializeField] private IntVariable killCountVariable;
    [SerializeField] private IntVariable bestKillCountVariable;
    [SerializeField] private TextMeshProUGUI killCountText;
    [SerializeField] private TextMeshProUGUI bestKillCountText;

    private void OnEnable() {
        UpdateUI();
    }

    public void AddKill() // is called OnEnemyDied
    {
        killCountVariable.SetValue(killCountVariable.Value + 1);
        Debug.Log("Kill Manager: Adding kill, current count is " + killCountVariable.Value);

        CheckBest();
        UpdateUI();
    }

    public void UpdateUI() // is called whenever you AddKill or Enable new Canvas window or OnGameReset
    {
        killCountText.text = killCountVariable.Value.ToString();
        bestKillCountText.text = "Best run " + bestKillCountVariable.Value.ToString();
    }

    private void CheckBest()
    {
        if(killCountVariable.Value <= bestKillCountVariable.Value) return;

        bestKillCountVariable.SetValue(killCountVariable.Value);
        Debug.Log("Kill Manager: You reached your best kill count yet");
    }
}

using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] private IntVariable goldVariable;
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start() {
        UpdateUI();
    }

    private void OnEnable() { // updates when new window is opened
        UpdateUI();
    }

    public void UpdateUI() // is called OnGoldChanged event
    {
        goldText.text = goldVariable.Value.ToString();
    }
}

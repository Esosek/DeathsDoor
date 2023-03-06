using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] private IntVariable goldVariable;
    [SerializeField] private TextMeshProUGUI goldText;

    public void UpdateUI() // is called OnGoldChanged event
    {
        goldText.text = goldVariable.Value.ToString();
    }
}

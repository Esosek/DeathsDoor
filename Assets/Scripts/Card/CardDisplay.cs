using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card Card
    {
        get { return assignedCard; }
        private set { assignedCard = value; }
    }
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Image[] art;
    [SerializeField] private TextMeshProUGUI[] ruleText;

    private Card assignedCard; // internal storage of what card was set
    
    public void SetCard(Card card) // is called whenever something creates card visuals (mainly HandDisplay)
    {
        Card = card;
        goldText.text = card.Gold.ToString(); // set gold text

        for (int i = 0; i < card.Art.Count; i++) // render art
        {
            if(art[i] == null) return; // prevent rendering if art images are not properly mapped
            art[i].sprite = card.Art[i];
        }

        for (int i = 0; i < card.Effects.Count; i++) // render rule text
        {
            if(ruleText[i] == null) return; // prevent rendering if textx are not properly mapped
            ruleText[i].text = card.Effects[i].RuleText;
        }
    }
}

using UnityEngine;
using TMPro;

public class CharacterDisplay : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI maxHealthText;
    [SerializeField] private TextMeshProUGUI attackText;

    [SerializeField] private Animator healthAnimator;

    private void Start() => UpdateAll();

    private void OnEnable() { // to be sure UI is updated on new window open
        UpdateAll();
    }

    private void UpdateAll()
    {
        UpdateHealth();
        UpdateStats();
        UpdateMaxHealth();
    }

    public void UpdateHealth() // is called OnHeroDamaged, OnHeroHealed and OnEnemyDamaged events
    {
        healthText.text = character.Health.ToString();        
    }

    public void OnHeal()
    {   
        UpdateHealth();
        if(healthAnimator != null) healthAnimator.SetTrigger("onGain");
    }

    public void UpdateStats() // is called OnEnemyStatsChanged
    {
        if(attackText == null) return;
        Enemy enemy = (Enemy) character;
        attackText.text = enemy.Attack.ToString();
        UpdateHealth();
    }

    public void UpdateMaxHealth() // is called OnHeroMaxHealthChanged
    {
        if(maxHealthText == null) return;
        maxHealthText.text = "Max " + character.MaxHealth.ToString();
    }
}

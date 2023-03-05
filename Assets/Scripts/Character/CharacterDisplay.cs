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

    private void UpdateAll()
    {
        UpdateHealth();
        UpdateAttack();
        UpdateMaxHealth();
    }

    public void UpdateHealth() // is called OnHeroDamaged, OnHeroHealed and OnEnemyDamaged events
    {
        healthText.text = character.Health.ToString();
        if(healthAnimator != null) healthAnimator.SetTrigger("onChange");
    }

    public void UpdateAttack() // is called OnEnemyAttackChanged
    {
        if(attackText == null) return;
        Enemy enemy = (Enemy) character;
        attackText.text = enemy.Attack.ToString();
    }

    public void UpdateMaxHealth() // is called OnHeroMaxHealthChanged
    {
        if(maxHealthText == null) return;
        maxHealthText.text = "Max " + character.MaxHealth.ToString();
        if(healthAnimator != null) healthAnimator.SetTrigger("onChange");
    }
}

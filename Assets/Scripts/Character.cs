using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "Character/Hero")]
public class Character : ScriptableObject 
{
    public int Health
    {
        get 
        { 
            if(currentHealth < 0) return 0; // returns 0 if it's negative - mostly for UI display
            else return currentHealth; 
        }
        protected set { currentHealth = value; }
    }

    [SerializeField] private int initialHealth;
    [SerializeField] private int currentHealth;
    [SerializeField] private int maxHealth;
    [SerializeField] private GameEvent onDamageTakenEvent;
    [SerializeField] private GameEvent onHeroHealedEvent;
    [SerializeField] private GameEvent onDeathEvent;

    public void TakeDamage(int value)
    {
        Health -= value; // subtract value
        onDamageTakenEvent.Raise(); // raise event

        if(Health == 0) Die(); // if you don't have any more health, you die
    }

    public void Heal(int value)
    {
        if(Health == maxHealth) return; // no healing if you are at full health
        Health += value; // add value
        if(Health > maxHealth) Health = maxHealth; // prevent exceeding max health
        if(onHeroHealedEvent != null) onHeroHealedEvent.Raise(); // raise event
    }

    public void Reset() // reset all modified variables on new game
    {
        currentHealth = initialHealth; // reset current health
        maxHealth = initialHealth; // reset max health
    }

    private void Die()
    {
        if(onDeathEvent != null) onDeathEvent.Raise(); // raise event
    }
}

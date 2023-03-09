using UnityEngine;

[CreateAssetMenu(fileName = "EnemyGen", menuName = "Enemy Generator")]
public class EnemyGenerator : ScriptableObject
{
    [SerializeField] private IntVariable killCountVariable; // is used for progressive difficulty multiplier
    [SerializeField] private int startingAttack; // starting enemy attack // 4
    [SerializeField] private int startingHealth; // starting eemy health // 20
    [SerializeField] private int attackStep; // base step for how much is attack increased // 1
    [SerializeField] private int healthStep; // base step for how much is health increased // 10
    [SerializeField] private Enemy enemy; // reference to Enemy

    private int currentAttack;
    private int currentHealth;

    public void GenerateEnemy()
    {
        ResetEnemy(); // first reset to default

        // then add upgrade
        currentAttack = killCountVariable.Value * attackStep + startingAttack; // attack is flatly increased by 1
        if(killCountVariable.Value > 5) currentAttack += (killCountVariable.Value - 5) * attackStep; // then increase by 1 more
        currentHealth = killCountVariable.Value * healthStep + currentHealth; // whil health scales with kill count

        enemy.SetStats(currentAttack, currentHealth); // set Enemy
    }

    public void ResetEnemy()
    {
        enemy.SetStats(startingAttack, startingHealth); // set Enemy
        currentAttack = startingAttack;
        currentHealth = startingHealth;
    }
}

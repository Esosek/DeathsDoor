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
    private int dynamicAttackIncrement = 0;

    public void GenerateEnemy()
    {
        int _enemyCurrentAttack = currentAttack;
        ResetEnemy(); // first reset to default

        // adjust attackStep when on killCount 5+
        if(killCountVariable.Value >= 5) dynamicAttackIncrement++;

        // then add upgrade
        currentAttack = (killCountVariable.Value + dynamicAttackIncrement) * attackStep + _enemyCurrentAttack; // attack is flatly increased by 1        
        currentHealth = killCountVariable.Value * healthStep + currentHealth; // while health scales with kill count

        // intended attack values
        // 3,4,5,6,7,8,10,13,17,22,28,35
        // 3,4,5,6,7,

        enemy.SetStats(currentAttack, currentHealth); // set Enemy
    }

    public void ResetEnemy()
    {
        enemy.SetStats(startingAttack, startingHealth); // set Enemy
        currentAttack = startingAttack;
        currentHealth = startingHealth;
    }

    public void ResetDynamicAttackIncrement() => dynamicAttackIncrement = 0; // called from GameManager on NewRun()
}

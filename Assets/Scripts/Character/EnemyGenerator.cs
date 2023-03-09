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
        if(killCountVariable.Value <= 6) currentAttack = killCountVariable.Value + startingAttack; // attack is flatly increased by 1 until he is at 10 attack
        else  currentAttack = enemy.Attack - 9 * attackStep + enemy.Attack; // then it should add 1,2,3,4,5,...
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

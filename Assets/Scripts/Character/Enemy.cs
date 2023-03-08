using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Character/Enemy")]
public class Enemy : Character 
{
    public int Attack // current attack used for damage resolver
    {
        get { return currentAttack; }
        private set { currentAttack = value; }
    }

    [SerializeField] private int currentAttack;
    [SerializeField] private GameEvent onEnemyStatsChangedEvent;

    public void SetStats(int attack, int health) // used by EnemyGenerator to set the correct stats
    {
        Attack = attack;
        Health = health;
        if(onEnemyStatsChangedEvent != null) onEnemyStatsChangedEvent.Raise();
    }
}

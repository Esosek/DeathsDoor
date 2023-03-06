using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Character hero;
    [SerializeField] private GameEvent onCombatResolvedEvent;

    public void ResolveCombat()
    {
        hero.TakeDamage(enemy.Attack);
        onCombatResolvedEvent.Raise();
    }
}

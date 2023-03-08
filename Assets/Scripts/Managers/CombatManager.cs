using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Character hero;
    [SerializeField] private GameEvent onCombatResolvedEvent;
    [SerializeField] private IntVariable tutorialStepVariable;

    public void ResolveCombat()
    {
        hero.TakeDamage(enemy.Attack);
        if(tutorialStepVariable.Value == 5) tutorialStepVariable.SetValue(tutorialStepVariable.Value + 1);
        onCombatResolvedEvent.Raise();
    }
}

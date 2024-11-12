using Assets.Scripts.Resources;
using Assets.Scripts.States.EnemyAnimationStates.Implementations;
using Assets.Scripts.States.EnemyAnimationStates.Interfaces;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationStateSystem : MonoBehaviour
{
    [field: SerializeField]
    public Animator Animator { get; private set; }

    [field: SerializeField]
    public NavMeshAgent Agent { get; private set; }

    [field: SerializeField]
    public EnemyFightSystem FightSystem { get; private set; }

    private IEnemyAnimationState _currentState = new EnemyIdleAnimationState();
    private IEnemyAnimationState _nextState;

    private void Update()
    {
        _nextState = _currentState.CheckingStateModification(this);
        if (_nextState != null)
        {
            _currentState.OnExit(this);
            _currentState = _nextState;
            _currentState.OnEnter(this);
        }
    }

    public bool CanTakeGunDamage()
    {
        return _currentState.CanTakeGunDamage();
    }

    public void ExecuteGunDamageAnimation(bool isFatal)
    {
        _currentState.PerformingAction(isFatal ? EnemyAnimationAction.DEATH : EnemyAnimationAction.DAMAGE);
    }

    public void ExecuteRunningAnimation()
    {
        _currentState.PerformingAction(EnemyAnimationAction.RUN);
    }

    public void ExecuteIdleAnimation()
    {
        _currentState.PerformingAction(EnemyAnimationAction.IDLE);
    }

    public void ExecuteLightAttackAnimation()
    {
        _currentState.PerformingAction(EnemyAnimationAction.LIGHT_ATK);
    }
}

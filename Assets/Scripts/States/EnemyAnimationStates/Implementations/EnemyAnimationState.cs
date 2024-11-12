using Assets.Scripts.Resources;
using Assets.Scripts.States.EnemyAnimationStates.Interfaces;

namespace Assets.Scripts.States.EnemyAnimationStates.Implementations
{
    public abstract class EnemyAnimationState : IEnemyAnimationState
    {
        public IEnemyAnimationState NextState { get; set; }
        public abstract bool CanTakeGunDamage();
        public abstract IEnemyAnimationState CheckingStateModification(EnemyAnimationStateSystem enemyAnimationStateSystem);
        public abstract void OnEnter(EnemyAnimationStateSystem enemyAnimationStateSystem);
        public abstract void OnExit(EnemyAnimationStateSystem enemyAnimationStateSystem);
        public abstract void PerformingAction(EnemyAnimationAction action);
    }
}

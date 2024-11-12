using Assets.Scripts.Resources;

namespace Assets.Scripts.States.EnemyAnimationStates.Interfaces
{
    public interface IEnemyAnimationState
    {
        void PerformingAction(EnemyAnimationAction action);
        IEnemyAnimationState CheckingStateModification(EnemyAnimationStateSystem enemyAnimationStateSystem);
        void OnEnter(EnemyAnimationStateSystem enemyAnimationStateSystem);
        void OnExit(EnemyAnimationStateSystem enemyAnimationStateSystem);
        bool CanTakeGunDamage();
    }
}

using Assets.Scripts.Resources;
using Assets.Scripts.States.EnemyAnimationStates.Interfaces;

namespace Assets.Scripts.States.EnemyAnimationStates.Implementations
{
    public class EnemyIdleAnimationState : EnemyAnimationState
    {
        public override bool CanTakeGunDamage()
        {
            return true;
        }

        public override IEnemyAnimationState CheckingStateModification(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {
            return NextState;
        }

        public override void OnEnter(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {
            enemyAnimationStateSystem.Animator.Play("Idle");
        }

        public override void OnExit(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {

        }

        public override void PerformingAction(EnemyAnimationAction action)
        {
            switch (action)
            {
                case EnemyAnimationAction.DAMAGE:
                    NextState = new EnemyDamageAnimationState();
                    break;
                case EnemyAnimationAction.DEATH:
                    NextState = new EnemyDeathAnimationState();
                    break;
                case EnemyAnimationAction.RUN:
                    NextState = new EnemyRunAnimationState();
                    break;
                default:
                    break;
            }
        }
    }
}

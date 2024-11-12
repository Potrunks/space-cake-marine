using Assets.Scripts.Resources;
using Assets.Scripts.States.EnemyAnimationStates.Interfaces;

namespace Assets.Scripts.States.EnemyAnimationStates.Implementations
{
    public class EnemyRunAnimationState : EnemyAnimationState
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
            enemyAnimationStateSystem.Agent.isStopped = false;
            enemyAnimationStateSystem.Animator.Play("Run");
        }

        public override void OnExit(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {
            enemyAnimationStateSystem.Agent.isStopped = true;
        }

        public override void PerformingAction(EnemyAnimationAction action)
        {
            switch (action)
            {
                case EnemyAnimationAction.IDLE:
                    NextState = new EnemyIdleAnimationState();
                    break;
                case EnemyAnimationAction.DAMAGE:
                    NextState = new EnemyDamageAnimationState();
                    break;
                case EnemyAnimationAction.DEATH:
                    NextState = new EnemyDeathAnimationState();
                    break;
                case EnemyAnimationAction.LIGHT_ATK:
                    NextState = new EnemyLightAttackAnimationState();
                    break;
                default:
                    break;
            }
        }
    }
}

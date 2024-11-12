using Assets.Scripts.Resources;
using Assets.Scripts.States.EnemyAnimationStates.Interfaces;

namespace Assets.Scripts.States.EnemyAnimationStates.Implementations
{
    public class EnemyDamageAnimationState : EnemyAnimationState
    {
        public override bool CanTakeGunDamage()
        {
            return true;
        }

        public override IEnemyAnimationState CheckingStateModification(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {
            if (NextState != null)
            {
                return NextState;
            }

            if (enemyAnimationStateSystem.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                NextState = new EnemyIdleAnimationState();
                return NextState;
            }

            return NextState;
        }

        public override void OnEnter(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {
            enemyAnimationStateSystem.Animator.Play("Damage");
        }

        public override void OnExit(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {

        }

        public override void PerformingAction(EnemyAnimationAction action)
        {
            switch (action)
            {
                case EnemyAnimationAction.DEATH:
                    NextState = new EnemyDeathAnimationState();
                    break;
                default:
                    break;
            }
        }
    }
}

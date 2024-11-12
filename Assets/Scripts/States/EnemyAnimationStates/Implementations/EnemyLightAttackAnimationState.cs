using Assets.Scripts.Resources;
using Assets.Scripts.States.EnemyAnimationStates.Interfaces;
using UnityEngine;

namespace Assets.Scripts.States.EnemyAnimationStates.Implementations
{
    public class EnemyLightAttackAnimationState : EnemyAnimationState
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

            AnimatorStateInfo animatorStateInfo = enemyAnimationStateSystem.Animator.GetCurrentAnimatorStateInfo(0);

            enemyAnimationStateSystem.FightSystem.TryLightAttackPlayer(animatorStateInfo);

            if (animatorStateInfo.normalizedTime >= 1f)
            {
                NextState = new EnemyIdleAnimationState();
                return NextState;
            }

            return NextState;
        }

        public override void OnEnter(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {
            enemyAnimationStateSystem.Animator.Play("LightAttack");
        }

        public override void OnExit(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {
            enemyAnimationStateSystem.FightSystem.OnEnemyFinishLightAttackAnimation();
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
                default:
                    break;
            }
        }
    }
}

using Assets.Scripts.Resources;
using Assets.Scripts.States.EnemyAnimationStates.Interfaces;
using UnityEngine;

namespace Assets.Scripts.States.EnemyAnimationStates.Implementations
{
    public class EnemyDeathAnimationState : EnemyAnimationState
    {
        public override bool CanTakeGunDamage()
        {
            return false;
        }

        public override IEnemyAnimationState CheckingStateModification(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {
            if (enemyAnimationStateSystem.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            {
                GameObject.Destroy(enemyAnimationStateSystem.gameObject, 5f);
            }

            return NextState;
        }

        public override void OnEnter(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {
            enemyAnimationStateSystem.Animator.Play("Death");
        }

        public override void OnExit(EnemyAnimationStateSystem enemyAnimationStateSystem)
        {

        }

        public override void PerformingAction(EnemyAnimationAction action)
        {

        }
    }
}

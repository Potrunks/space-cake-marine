using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterMovementStates.Interfaces;

namespace Assets.Scripts.States.PlayableCharacterMovementStates.Implementations
{
    public class PlayableCharacterAimState : PlayableCharacterMovementState
    {
        public override IPlayableCharacterMovementState CheckingStateModification(PlayableCharacterController playableCharacterController)
        {
            return NextState ?? null;
        }

        public override void OnEnter(PlayableCharacterController playableCharacterController)
        {
            playableCharacterController.Animator.Play("Aim");
        }

        public override void OnExit(PlayableCharacterController playableCharacterController)
        {

        }

        public override void PerformingAction(PlayableCharacterAction action)
        {
            switch (action)
            {
                case PlayableCharacterAction.MOVE:
                    NextState = new PlayableCharacterRunState();
                    break;
                case PlayableCharacterAction.STOP:
                    NextState = new PlayableCharacterStopState();
                    break;
                default:
                    break;
            }
        }
    }
}

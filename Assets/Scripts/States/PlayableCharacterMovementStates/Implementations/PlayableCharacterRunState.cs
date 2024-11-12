using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterMovementStates.Interfaces;

namespace Assets.Scripts.States.PlayableCharacterMovementStates.Implementations
{
    public class PlayableCharacterRunState : PlayableCharacterMovementState
    {
        public override IPlayableCharacterMovementState CheckingStateModification(PlayableCharacterController playableCharacterController)
        {
            return NextState ?? null;
        }

        public override void OnEnter(PlayableCharacterController playableCharacterController)
        {
            playableCharacterController.Animator.Play("Run");
        }

        public override void OnExit(PlayableCharacterController playableCharacterController)
        {

        }

        public override void PerformingAction(PlayableCharacterAction action)
        {
            switch (action)
            {
                case PlayableCharacterAction.STOP:
                    NextState = new PlayableCharacterStopState();
                    break;
                case PlayableCharacterAction.AIM:
                    NextState = new PlayableCharacterAimState();
                    break;
                default:
                    break;
            }
        }
    }
}

using Assets.Scripts.Resources;

namespace Assets.Scripts.States.PlayableCharacterMovementStates.Interfaces
{
    public interface IPlayableCharacterMovementState
    {
        void PerformingAction(PlayableCharacterAction action);
        IPlayableCharacterMovementState CheckingStateModification(PlayableCharacterController playableCharacterController);
        void OnEnter(PlayableCharacterController playableCharacterController);
        void OnExit(PlayableCharacterController playableCharacterController);
    }
}

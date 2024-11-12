using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterMovementStates.Interfaces;

namespace Assets.Scripts.States.PlayableCharacterMovementStates.Implementations
{
    public abstract class PlayableCharacterMovementState : IPlayableCharacterMovementState
    {
        public IPlayableCharacterMovementState NextState { get; set; }
        public abstract IPlayableCharacterMovementState CheckingStateModification(PlayableCharacterController playableCharacterController);
        public abstract void OnEnter(PlayableCharacterController playableCharacterController);
        public abstract void OnExit(PlayableCharacterController playableCharacterController);
        public abstract void PerformingAction(PlayableCharacterAction action);
    }
}

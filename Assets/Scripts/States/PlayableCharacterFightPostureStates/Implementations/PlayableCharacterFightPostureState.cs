using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterFightPostureStates.Interfaces;

namespace Assets.Scripts.States.PlayableCharacterFightPostureStates.Implementations
{
    public abstract class PlayableCharacterFightPostureState : IPlayableCharacterFightPostureState
    {
        public IPlayableCharacterFightPostureState NextState { get; set; }
        public abstract IPlayableCharacterFightPostureState CheckingStateModification(PlayableCharacterFightSystem playableCharacterFightSystem);
        public abstract void OnEnter(PlayableCharacterFightSystem playableCharacterFightSystem);
        public abstract void OnExit(PlayableCharacterFightSystem playableCharacterFightSystem);
        public abstract void PerformingAction(PlayableCharacterAction action);
    }
}

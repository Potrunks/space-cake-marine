using Assets.Scripts.Resources;

namespace Assets.Scripts.States.PlayableCharacterFightPostureStates.Interfaces
{
    public interface IPlayableCharacterFightPostureState
    {
        void PerformingAction(PlayableCharacterAction action);
        IPlayableCharacterFightPostureState CheckingStateModification(PlayableCharacterFightSystem playableCharacterFightSystem);
        void OnEnter(PlayableCharacterFightSystem playableCharacterFightSystem);
        void OnExit(PlayableCharacterFightSystem playableCharacterFightSystem);
    }
}

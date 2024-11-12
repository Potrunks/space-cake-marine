using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterFightPostureStates.Interfaces;

namespace Assets.Scripts.States.PlayableCharacterFightPostureStates.Implementations
{
    public class PlayableCharacterStopPostureState : PlayableCharacterFightPostureState
    {
        public override IPlayableCharacterFightPostureState CheckingStateModification(PlayableCharacterFightSystem playableCharacterFightSystem)
        {
            return NextState ?? null;
        }

        public override void OnEnter(PlayableCharacterFightSystem playableCharacterFightSystem)
        {

        }

        public override void OnExit(PlayableCharacterFightSystem playableCharacterFightSystem)
        {
            if (NextState.GetType() == typeof(PlayableCharacterAimPostureState))
            {
                playableCharacterFightSystem.OnPlayerAimInput.Raise();
            }

            if (NextState.GetType() == typeof(PlayableCharacterFirePostureState))
            {
                playableCharacterFightSystem.OnPlayerFireInput.Raise();
            }
        }

        public override void PerformingAction(PlayableCharacterAction action)
        {
            switch (action)
            {
                case PlayableCharacterAction.AIM:
                    NextState = new PlayableCharacterAimPostureState();
                    break;
                case PlayableCharacterAction.FIRE:
                    NextState = new PlayableCharacterFirePostureState();
                    break;
                default:
                    break;
            }
        }
    }
}

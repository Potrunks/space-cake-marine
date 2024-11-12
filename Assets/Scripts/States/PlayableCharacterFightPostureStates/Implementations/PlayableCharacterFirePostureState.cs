using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterFightPostureStates.Interfaces;

namespace Assets.Scripts.States.PlayableCharacterFightPostureStates.Implementations
{
    public class PlayableCharacterFirePostureState : PlayableCharacterFightPostureState
    {
        public override IPlayableCharacterFightPostureState CheckingStateModification(PlayableCharacterFightSystem playableCharacterFightSystem)
        {
            return NextState ?? null;
        }

        public override void OnEnter(PlayableCharacterFightSystem playableCharacterFightSystem)
        {
            playableCharacterFightSystem.OnPlayerUsingNoPrecisionGun.Raise(playableCharacterFightSystem.Gun);
        }

        public override void OnExit(PlayableCharacterFightSystem playableCharacterFightSystem)
        {
            playableCharacterFightSystem.OnPlayerStopUsingGun.Raise();

            if (NextState.GetType() == typeof(PlayableCharacterStopPostureState))
            {
                playableCharacterFightSystem.OnPlayerFireRelease.Raise();
            }

            if (NextState.GetType() == typeof(PlayableCharacterAimFirePostureState))
            {
                playableCharacterFightSystem.OnPlayerFireAimInput.Raise();
            }
        }

        public override void PerformingAction(PlayableCharacterAction action)
        {
            switch (action)
            {
                case PlayableCharacterAction.STOP_FIRE:
                    NextState = new PlayableCharacterStopPostureState();
                    break;
                case PlayableCharacterAction.AIM:
                    NextState = new PlayableCharacterAimFirePostureState();
                    break;
                default:
                    break;
            }
        }
    }
}

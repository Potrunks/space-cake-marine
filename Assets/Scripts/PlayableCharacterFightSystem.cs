using Assets.Scripts.GameEvents.ScriptableObjects;
using Assets.Scripts.Resources;
using Assets.Scripts.ScriptableObjects;
using Assets.Scripts.States.PlayableCharacterFightPostureStates.Implementations;
using Assets.Scripts.States.PlayableCharacterFightPostureStates.Interfaces;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayableCharacterFightSystem : MonoBehaviour
{
    [field: Header("--- Events ---")]
    [field: SerializeField]
    public GameEvent OnPlayerAimInput { get; private set; }

    [field: SerializeField]
    public GameEvent OnPlayerAimRelease { get; private set; }

    [field: SerializeField]
    public GameEvent OnPlayerFireInput { get; private set; }

    [field: SerializeField]
    public GameEvent OnPlayerFireRelease { get; private set; }

    [field: SerializeField]
    public GameEvent OnPlayerAimFireInput { get; private set; }

    [field: SerializeField]
    public GameEvent OnPlayerAimFireRelease { get; private set; }

    [field: SerializeField]
    public GameEvent OnPlayerFireAimInput { get; private set; }

    [field: SerializeField]
    public GameEvent OnPlayerFireAimRelease { get; private set; }

    [field: SerializeField]
    public GunGameEvent OnPlayerUsingPrecisionGun { get; private set; }

    [field: SerializeField]
    public GunGameEvent OnPlayerUsingNoPrecisionGun { get; private set; }

    [field: SerializeField]
    public GameEvent OnPlayerStopUsingGun { get; private set; }

    [field: Header("--- Weapon ---")]
    [field: SerializeField]
    public Gun Gun { get; private set; }

    private IPlayableCharacterFightPostureState _currentFightPostureState = new PlayableCharacterStopPostureState();
    private IPlayableCharacterFightPostureState _nextFightPostureState;

    public void Aim(CallbackContext context)
    {
        if (context.performed)
        {
            _currentFightPostureState.PerformingAction(PlayableCharacterAction.AIM);
        }

        if (context.canceled)
        {
            _currentFightPostureState.PerformingAction(PlayableCharacterAction.STOP_AIM);
        }

        ChangeFightPostureState();
    }

    public void Fire(CallbackContext context)
    {
        if (context.performed)
        {
            _currentFightPostureState.PerformingAction(PlayableCharacterAction.FIRE);
        }

        if (context.canceled)
        {
            _currentFightPostureState.PerformingAction(PlayableCharacterAction.STOP_FIRE);
        }

        ChangeFightPostureState();
    }

    private void ChangeFightPostureState()
    {
        _nextFightPostureState = _currentFightPostureState.CheckingStateModification(this);
        if (_nextFightPostureState != null)
        {
            _currentFightPostureState.OnExit(this);
            _currentFightPostureState = _nextFightPostureState;
            _currentFightPostureState.OnEnter(this);
        }
    }
}

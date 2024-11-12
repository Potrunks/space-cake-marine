using Assets.Scripts.GameEvents.ScriptableObjects;
using Assets.Scripts.Resources;
using Assets.Scripts.States.PlayableCharacterMovementStates.Implementations;
using Assets.Scripts.States.PlayableCharacterMovementStates.Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayableCharacterController : MonoBehaviour
{
    [field: SerializeField]
    public CharacterController CharacterController { get; private set; }

    [field: SerializeField]
    public Transform MainCamera { get; private set; }

    [field: SerializeField]
    public float Speed { get; private set; } = 5f;

    [field: SerializeField]
    public float SmoothRotation { get; private set; } = 0.1f;

    [field: SerializeField]
    public Animator Animator { get; private set; }

    [field: SerializeField]
    public PlayerInput PlayerInput { get; private set; }

    [field: Header("--- Events ---")]
    [field: SerializeField]
    public GameObjectGameEvent OnNewPlayableCharacterComeInGame { get; private set; }

    [field: SerializeField]
    public PlayerInputGameEvent OnPlayableCharacterGamePause { get; private set; }

    [field: SerializeField]
    public PlayerInputGameEvent OnPlayableCharacterGameResume { get; private set; }

    private Vector2 _inputMoveValue;
    private float _refVelocity;
    private IPlayableCharacterMovementState _currentMovementState = new PlayableCharacterStopState();
    private IPlayableCharacterMovementState _nextMovementState;
    private bool _isAiming = false;

    private void Start()
    {
        OnNewPlayableCharacterComeInGame.Raise(gameObject);
    }

    private void FixedUpdate()
    {
        Vector3 rawDirection = new Vector3(_inputMoveValue.x, 0f, _inputMoveValue.y).normalized;

        if (rawDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(rawDirection.x, rawDirection.z) * Mathf.Rad2Deg + MainCamera.eulerAngles.y;
            float smoothTargetAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _refVelocity, SmoothRotation);
            transform.rotation = Quaternion.Euler(0f, smoothTargetAngle, 0f);

            Vector3 direction = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            CharacterController.SimpleMove(direction.normalized * Speed * Time.deltaTime);

            _currentMovementState.PerformingAction(PlayableCharacterAction.MOVE);
        }
        else
        {
            _currentMovementState.PerformingAction(_isAiming ? PlayableCharacterAction.AIM : PlayableCharacterAction.STOP);
        }

        _nextMovementState = _currentMovementState.CheckingStateModification(this);
        if (_nextMovementState != null)
        {
            _currentMovementState.OnExit(this);
            _currentMovementState = _nextMovementState;
            _currentMovementState.OnEnter(this);
        }
    }

    public void Move(CallbackContext context)
    {
        _inputMoveValue = context.ReadValue<Vector2>();
    }

    public void Aim()
    {
        _isAiming = true;
    }

    public void StopAim()
    {
        _isAiming = false;
    }

    public void GamePause(CallbackContext context)
    {
        if (context.started)
        {
            OnPlayableCharacterGamePause.Raise(PlayerInput);
        }
    }

    public void GameResume(CallbackContext context)
    {
        if (context.started)
        {
            OnPlayableCharacterGameResume.Raise(PlayerInput);
        }
    }
}

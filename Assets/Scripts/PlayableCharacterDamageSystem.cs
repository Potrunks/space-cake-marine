using Assets.Scripts.GameEvents.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayableCharacterDamageSystem : MonoBehaviour
{
    [field: SerializeField]
    public float Health { get; private set; }

    [field: SerializeField]
    public GameObject AliveModel { get; private set; }

    [field: SerializeField]
    public GameObject DeadModel { get; private set; }

    [field: SerializeField]
    public FloatGameEvent OnStartPlayableCharacterDamageSystem { get; private set; }

    [field: SerializeField]
    public FloatGameEvent OnPlayableCharacterTakeBodyDamage { get; private set; }

    [field: SerializeField]
    public PlayerInput PlayerInput { get; private set; }

    [field: Header("--- Events ---")]
    [field: SerializeField]
    public GameEvent OnPlayerDead { get; private set; }

    private void Start()
    {
        OnStartPlayableCharacterDamageSystem.Raise(Health);
    }

    public void TakeBodyDamage(float damage)
    {
        if (Health > 0)
        {
            Health -= damage;
            OnPlayableCharacterTakeBodyDamage.Raise(Health);

            if (Health <= 0)
            {
                AliveModel.SetActive(false);
                PlayerInput.DeactivateInput();
                DeadModel.SetActive(true);
                OnPlayerDead.Raise();
            }
        }
    }
}

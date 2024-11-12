using Assets.Scripts.GameEvents.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [field: SerializeField]
    public GameEvent GameEvent { get; private set; }

    [field: SerializeField]
    public UnityEvent Response { get; private set; }

    private void OnEnable()
    {
        GameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        GameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        Response.Invoke();
    }
}

using Assets.Scripts.GameEvents.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.GameEvents.Listeners
{
    public class TypedGameEventListener<T> : MonoBehaviour
    {
        [field: SerializeField]
        public TypedGameEvent<T> GameEvent { get; private set; }

        [field: SerializeField]
        public UnityEvent<T> Response { get; private set; }

        private void OnEnable()
        {
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T value)
        {
            Response.Invoke(value);
        }
    }
}

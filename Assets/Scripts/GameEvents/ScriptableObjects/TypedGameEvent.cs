using Assets.Scripts.GameEvents.Listeners;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameEvents.ScriptableObjects
{
    public class TypedGameEvent<T> : ScriptableObject
    {
        private List<TypedGameEventListener<T>> _listeners = new List<TypedGameEventListener<T>>();

        public void Raise(T value)
        {
            foreach (TypedGameEventListener<T> listener in _listeners)
            {
                listener.OnEventRaised(value);
            }
        }

        public void RegisterListener(TypedGameEventListener<T> listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(TypedGameEventListener<T> listener)
        {
            _listeners.Remove(listener);
        }
    }
}

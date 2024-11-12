using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.GameEvents.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Event/No Type")]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> _listeners = new List<GameEventListener>();

        public void Raise()
        {
            foreach (GameEventListener listener in _listeners)
            {
                listener.OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }
}

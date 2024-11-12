using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.GameEvents.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Event/Player Input")]
    public class PlayerInputGameEvent : TypedGameEvent<PlayerInput>
    {
    }
}

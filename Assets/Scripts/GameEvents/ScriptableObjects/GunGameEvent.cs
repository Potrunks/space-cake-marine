using Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace Assets.Scripts.GameEvents.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Game Event/Gun")]
    public class GunGameEvent : TypedGameEvent<Gun>
    {
    }
}

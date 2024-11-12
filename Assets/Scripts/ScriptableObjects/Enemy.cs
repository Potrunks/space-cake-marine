using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "NPC/Enemy")]
    public class Enemy : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public float MaxHealthPoint { get; private set; }

        [field: SerializeField]
        public float Force { get; private set; }
    }
}

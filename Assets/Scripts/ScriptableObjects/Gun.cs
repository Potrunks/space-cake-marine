using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Weapon/Gun")]
    public class Gun : ScriptableObject
    {
        [field: SerializeField]
        public string Name { get; private set; }

        [field: SerializeField]
        public float ZoomRecoil { get; private set; }

        [field: SerializeField]
        public float Recoil { get; private set; }

        [field: SerializeField]
        public float Damage { get; private set; }

        [field: SerializeField]
        public float FireRate { get; private set; }

        [field: SerializeField]
        public GameObject ImpactEffectPrefab { get; private set; }
    }
}

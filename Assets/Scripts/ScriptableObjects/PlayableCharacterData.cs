using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Data/PlayableCharacter")]
    public class PlayableCharacterData : ScriptableObject
    {
        [field: SerializeField]
        public List<GameObject> PlayableCharactersInGame { get; set; }
    }
}

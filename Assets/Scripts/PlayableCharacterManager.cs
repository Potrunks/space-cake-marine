using Assets.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

public class PlayableCharacterManager : MonoBehaviour
{
    [field: SerializeField]
    public PlayableCharacterData PlayableCharacterData { get; private set; }

    private void Awake()
    {
        PlayableCharacterData.PlayableCharactersInGame = new List<GameObject>();
    }

    public void SaveNewPlayableCharacterInGame(GameObject gameObject)
    {
        PlayableCharacterData.PlayableCharactersInGame.Add(gameObject);
    }
}

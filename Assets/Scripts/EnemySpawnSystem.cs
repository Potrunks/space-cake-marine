using Assets.Scripts.GameEvents.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnSystem : MonoBehaviour
{
    [field: SerializeField]
    public List<Transform> SpawnPoints { get; private set; }

    [field: SerializeField]
    public GameObject EnemyPrefab { get; private set; }

    [field: SerializeField]
    public int NumberEnemyToSpawn { get; private set; }

    [field: SerializeField]
    public float TimeBetweenSpawns { get; private set; }

    [field: SerializeField]
    public float TimeBetweenWaves { get; private set; }

    [field: Header("--- Events ---")]
    [field: SerializeField]
    public FloatGameEvent OnWaveSpawnStarted { get; private set; }

    private int _currentWaveNb = 0;

    private void Start()
    {
        _currentWaveNb++;
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        OnWaveSpawnStarted.Raise(TimeBetweenWaves);

        int spawnedEnemies = 0;

        while (spawnedEnemies < (NumberEnemyToSpawn * _currentWaveNb))
        {
            foreach (Transform spawnPoint in SpawnPoints)
            {
                if (spawnedEnemies < (NumberEnemyToSpawn * _currentWaveNb))
                {
                    Instantiate(EnemyPrefab, spawnPoint.position, spawnPoint.rotation, transform);
                    spawnedEnemies++;
                }
                else
                {
                    break;
                }
            }
            yield return new WaitForSeconds(TimeBetweenSpawns);
        }
    }

    public void StartNewEnemiesWave()
    {
        _currentWaveNb++;
        StartCoroutine(SpawnEnemiesCoroutine());
    }
}

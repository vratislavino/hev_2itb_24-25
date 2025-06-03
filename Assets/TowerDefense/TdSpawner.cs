using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TdSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform spawnpoint;

    [SerializeField]
    private float spawnInterval = 2f;

    [SerializeField]
    private List<TdEnemy> enemyPrefabs;

    [SerializeField]
    private int maxEnemies = 10;

    void Start()
    {
        StartCoroutine(SpawnEnemiesRoutine());
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(GetRandomPrefab(), spawnpoint.position, Quaternion.identity);
    }

    private TdEnemy GetRandomPrefab()
    {
        return enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Count)];
    }
}

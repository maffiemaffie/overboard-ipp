using System;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 5f;
    public Vector3 spawnAreaSize;

    void Start()
    {
        InvokeRepeating(nameof(SpawnCoin), 1f, spawnInterval);
    }

    void SpawnCoin()
    {
        Vector3 spawnPos = new Vector3(
            UnityEngine.Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            1f,
            UnityEngine.Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );


        Instantiate(coinPrefab, spawnPos, Quaternion.identity);
    }
}

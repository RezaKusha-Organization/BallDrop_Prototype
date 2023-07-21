using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _powerupPrefab;
    private float spawnRange = 9;
    private int enemyCount;
    private int waveNumber = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(_powerupPrefab, RandomSpawnPos(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(_powerupPrefab, RandomSpawnPos(), Quaternion.identity);
        }
    }

    Vector3 RandomSpawnPos()
    {
        float xRange = Random.Range(-spawnRange, spawnRange);
        float zRange = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(xRange, 0, zRange);
        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++ )
        {
            Instantiate(_enemyPrefab, RandomSpawnPos(), Quaternion.identity);
        }
    }
}

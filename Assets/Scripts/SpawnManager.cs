using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    private float spawnRange = 9;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Instantiate(_enemyPrefab, RandomSpawnPos(), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomSpawnPos()
    {
        float xRange = Random.Range(-spawnRange, spawnRange);
        float zRange = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(xRange, 0, zRange);
        return randomPos;
    }
}

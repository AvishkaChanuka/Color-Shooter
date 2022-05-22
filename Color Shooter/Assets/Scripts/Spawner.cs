using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoinnts;
    [SerializeField] GameObject[] enemies;
    public float spawnRate = 1f;
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int RandomPosition()
    {
        return Random.Range(0, spawnPoinnts.Length);
    }

    int RandomEnemy()
    {
        return Random.Range(0, enemies.Length);
    }


    void SpawnEnemy()
    {
        Instantiate(enemies[RandomEnemy()], spawnPoinnts[RandomPosition()].position, spawnPoinnts[RandomPosition()].rotation);
    }
}

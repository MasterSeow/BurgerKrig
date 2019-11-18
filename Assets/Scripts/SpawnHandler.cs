using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    public GameObject handler;

    public List<GameObject> spawnPoints;
    public float spawnRate;


    private int Wave = 1;
    private int EnemiesSpawned = 0;
    private int EnemiesDied = 0;

    private float nextSpawn;


    void Update()
    {

        if (Time.time > nextSpawn)
        {
            if (EnemiesSpawned < Wave)
            {
                spawnPoints[Random.Range(0, 6)].GetComponent<EnemySpawnPoint>().spawnEnemy();
                EnemiesSpawned++;
            }
            else if (EnemiesSpawned <= EnemiesDied)
            {
                Wave++;
                ScoreHandler.setWave(Wave);
                EnemiesSpawned = 0;
                EnemiesDied = 0;
            }
            nextSpawn = Time.time + spawnRate;
        }
    }

    public void enemyDied()
    {
        ScoreHandler.incEnemiesKilled();
        EnemiesDied++;
    }
}

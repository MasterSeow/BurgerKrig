using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour
{
    public GameObject enemyModel;
    public float enemySpeed;
    public Rigidbody _player;
    public GameObject Handler;

    public void spawnEnemy()
    {
        GameObject enemy = Instantiate(enemyModel, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1f), gameObject.transform.rotation);
        SimpleEnemyBehaviour beh = enemy.AddComponent<SimpleEnemyBehaviour>();
        beh._player = _player;
        beh.speed = enemySpeed;
        beh.Handler = Handler;

    }
}

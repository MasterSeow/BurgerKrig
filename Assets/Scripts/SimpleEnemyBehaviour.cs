using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyBehaviour : MonoBehaviour
{
    public float speed;
    public Rigidbody _player;


    public GameObject Handler;

    private Rigidbody _body;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    void Update()
    {
       
        _body = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        lookAtPlayer();
        _body.MovePosition(_body.position + transform.right * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Bullet"))
        {
            Handler.GetComponent<SpawnHandler>().enemyDied();
            other.GetComponent<PickleBehaviour>().enemyHit();
            Destroy(gameObject);
        }

        if (other.gameObject.tag.Equals("Player"))
            Handler.GetComponent<LevelManagement>().GameOver();

    }

    void lookAtPlayer()
    {
        Vector3 difference = _player.transform.position - transform.position; //Get Cursorposition
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Get Rotation in Degree
        _body.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 0); //Rotate 
    }
}

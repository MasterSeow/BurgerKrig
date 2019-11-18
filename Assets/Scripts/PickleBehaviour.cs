using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickleBehaviour : MonoBehaviour
{
    public float speed;


    public float maxlifetime = 25;

    private int EnemiesKilled = 0;

    private float lifetime;
    private Rigidbody _body;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        lifetime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;

        if (lifetime >= maxlifetime)
        {
            ScoreHandler.updateMostEnemiesHitAtOnce(EnemiesKilled);
            Destroy(gameObject);
        }
        _body = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        _body.MovePosition(_body.position + transform.right * speed * Time.fixedDeltaTime);
    }

    public void enemyHit()
    {
        EnemiesKilled++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Wall"))
        {
            ScoreHandler.updateMostEnemiesHitAtOnce(EnemiesKilled);
            Destroy(gameObject);
        }
    }
}

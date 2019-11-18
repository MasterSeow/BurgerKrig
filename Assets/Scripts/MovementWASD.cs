using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWASD : MonoBehaviour
{
    public int movementspeed = 1;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;

    private void Start()
    {
        _body = GetComponent<Rigidbody>();

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _inputs.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _inputs.x += 1;

        }
        if (Input.GetKey(KeyCode.W))
        {
            _inputs.y += 1;

        }
        if (Input.GetKey(KeyCode.S))
        {
            _inputs.y -= 1;

        }
        _body = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * movementspeed * Time.fixedDeltaTime);
        _inputs = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        _inputs = Vector3.zero;
    }
}

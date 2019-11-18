using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerBehavior : MonoBehaviour
{

    public GameObject shotModel;
    public Transform shotSpawn;
    public float fireRate;
    public float bulletLifetime;
    public float bulletSpeed;

    private float nextFire;

    void Update()
    {
        cursorFollow();
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject shot =  Instantiate(shotModel, new Vector3(shotSpawn.position.x, shotSpawn.position.y, -1f), shotSpawn.rotation);
            PickleBehaviour beh =  shot.AddComponent<PickleBehaviour>();
            beh.maxlifetime = bulletLifetime;
            beh.speed = bulletSpeed;

            ScoreHandler.incBulletsShot();

        }
    }

    void cursorFollow()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //Get Cursorposition
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Get Rotation in Degree
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 0); //Rotate cursor
    }

}

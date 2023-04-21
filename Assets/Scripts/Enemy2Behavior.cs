using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Behavior : MonoBehaviour {

    // Standard ranged enemy that shoots from afar (idk like 3 enemy spaces)

    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float speed = 2f;
    Rigidbody2D rb;
    Transform target;

    public float distanceToStop = 3f;
/*
    public float distanceToShoot = 5f;
    public float fireRate;
    private float timeToFire = 0;
    public Transform firingPoint;
    public GameObject bulletPrefab; */


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        target = GameObject.Find("UFO").transform;
    }

    void Update() {
        var distance = Vector2.Distance(transform.position,target.position);
        if (distance >= distanceToStop) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        /*if (distance >= distanceToShoot) {
            Shoot();
        } */
    }

/*    private void Shoot() {
        if (timeToFire <= 0f) {
            Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation);
            timeToFire = fireRate;
        }
        else {
            timeToFire -= Time.deltaTime;
        }
    }*/
}
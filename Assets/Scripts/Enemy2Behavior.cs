using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Behavior : MonoBehaviour {

    // Standard ranged enemy that shoots from afar (idk like 3 enemy spaces)

    [SerializeField] float health, maxHealth = 3f;
    [SerializeField] float speed = 2f;
    Rigidbody2D rb;
    Transform target;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        target = GameObject.Find("UFO").transform;
    }

    void Update() {
        var distance = Vector3.Distance(transform.position,target.position);
        if (distance > 3) {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Behavior : MonoBehaviour {

    // Standard tank enemy that moves slow but does a lot of damage

    [SerializeField] float health, maxHealth = 10f;
    [SerializeField] float speed = 1f;
    Rigidbody2D rb;
    Transform target;

    private const float BULLET_DAMAGE = 1f;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        target = GameObject.Find("UFO").transform;
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    /*
      * When the enemy collides with a bullet, it takes damage
      */
    void OnCollisionEnter2D(Collision2D collision) {
      Debug.Log("Collision with " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Projectile") {
            health -= BULLET_DAMAGE;
            if (health <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
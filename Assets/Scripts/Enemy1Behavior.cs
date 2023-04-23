using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Behavior : MonoBehaviour {

    // Standard run-into-you enemy

    [SerializeField] float health, maxHealth = 5f;
    [SerializeField] float speed = 4f;
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




// Prototype movement, leave commented.
/*    private void Update() {
        if (target) {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation  = angle;
            moveDirection = direction;
        }
    }

    void FixedUpdate() {
        if (target) {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
        }
    } */
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

    public float distanceToShoot = 5f;
    public float fireRate = 0;
    private float timeToFire = 0;

    public ProjectileBehavior bullet;

    private const float BULLET_DAMAGE = 1f;

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
        Shoot();
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

    /*
      * Shoots a bullet at the player
      */
    void Shoot() {
        if (timeToFire <= 0f) {
            Debug.Log("Shooting");

            // set rotation of bullet towards player
            Vector3 difference = target.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            // rotate z by 180 degrees
            rotationZ += 180;

            // shoot bullet
            Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, rotationZ));

            timeToFire = fireRate;
        }
        else {
            timeToFire -= Time.deltaTime;
        }
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
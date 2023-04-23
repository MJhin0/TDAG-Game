using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    public Text healthText;

    public float dashCooldown = 0;

    public float health = 100f;

    private Rigidbody2D rBody;

    public ProjectileBehavior bullet;
    public Transform launchOffset;

    // just took damage
    private bool isInvincible = false;
    // time when just took damage
    private float justTookDamageTime = 0f;
    // invincibility frame = 3 seconds
    private float invincibilityTime = 2.5f;

    // constant damage taken from enemy collision
    const float damageFromEnemy = 10f;

    // Start is called before the first frame update
    void Start()
    {
        // Able to controller UFO's Rigidbody
        rBody = GetComponent<Rigidbody2D>();
        healthText.text = "Health: " + health.ToString();
    }

    // Update is called once per frame (however often that is)
    void FixedUpdate()
    {
        //WASD Controls
        float horizontalIn = Input.GetAxis("Horizontal");
        float verticalIn = Input.GetAxis("Vertical");

        //Rotate towards mouse
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);

        rBody.position = rBody.position + new Vector2(horizontalIn, verticalIn) * speed * Time.fixedDeltaTime;
        
        //Dash updating
        if(dashCooldown > 0){
          dashCooldown -= (float) 0.05;
          speed = dashCooldown * 10f + 10f;
        }
        else{
          speed = 10f;
          dashCooldown = 0;
        }

        // if just took damage and time is greater than invincibility time
        if(isInvincible && Time.time - justTookDamageTime > invincibilityTime) {
          Debug.Log("Not invincible anymore");
          isInvincible = false;
          // set opacity back to normal
          GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1.0f);
        }
    }

    void Update(){
        //Fire bullet
        if(Input.GetButtonDown("Fire1")){
            Instantiate(bullet, launchOffset.position, transform.rotation * Quaternion.Euler(0, 0, -90));
        }
        //Start dash
        if(Input.GetButtonDown("Fire2") && dashCooldown <= 0){
            speed = (float) 15f;
            dashCooldown = 1;
        }
    }

    // Unity create a detect collision method
    void OnCollisionEnter2D(Collision2D other){
      // check if it's an enemy and not invincible
      if ((other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyProjectile") && !isInvincible) {
        // set invincible
        isInvincible = true;

        // set opacity faded to indiciate invincibility
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);

        // mark time set invincible
        justTookDamageTime = Time.time;

        // subtract health
        health -= damageFromEnemy;

        Debug.Log("Health: " + health);

        // handle player death
        if(health <= 0f) {
          // TODO: handle player death
          Destroy(gameObject);
          SceneManager.LoadScene(2);
        }

        // self destruct the enemy
        Destroy(other.gameObject);
      } else if (other.gameObject.tag == "Enemy" && isInvincible) {
        // just self destruct the enemy
        Destroy(other.gameObject);
      }
      healthText.text = "Health: " + health.ToString();
    }
}

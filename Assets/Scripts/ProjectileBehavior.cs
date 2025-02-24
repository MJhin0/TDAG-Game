using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 5.0f;
    public float vertAngle;
    public float horizAngle;
    public bool isEnemyProjectile = false;

    private Rigidbody2D rBody;

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision){
      if (!isEnemyProjectile) {
        Destroy(gameObject);
      }else if (collision.gameObject.tag != "Enemy"){
        Destroy(gameObject);
      }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float speed = 3.0f;
    public float vertAngle;
    public float horizAngle;

    private Rigidbody2D rBody;

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject);
    }

}

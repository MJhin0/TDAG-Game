using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;

    private Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        // Able to controller UFO's Rigidbody
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame (however often that is)
    void FixedUpdate()
    {
        //WASD Controls
        float horizontalIn = Input.GetAxis("Horizontal");
        float verticalIn = Input.GetAxis("Vertical");

        //rBody.AddForce(new Vector2(horizontalIn, verticalIn) * speed);
        rBody.position = rBody.position + new Vector2(horizontalIn, verticalIn) * speed * Time.fixedDeltaTime;

    }
}

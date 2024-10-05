using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float horizontalSpeed;
    float verticalSpeed;
    Rigidbody2D rigidBody;
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        verticalSpeed = Input.GetAxisRaw("Vertical");
        rigidBody.velocity = new Vector2(horizontalSpeed, verticalSpeed).normalized * speed;

        Vector3 scale = transform.localScale;
        if (horizontalSpeed > 0) {
            scale.x = -1;
        } else if (horizontalSpeed < 0) {
            scale.x = 1;
        }
        transform.localScale = scale;
    }
}
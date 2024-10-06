using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    float horizontalSpeed;
    float verticalSpeed;
    float boostTimer = 1;
    Rigidbody2D rigidBody;
    bool cheeseBoost = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        verticalSpeed = Input.GetAxisRaw("Vertical");

        if (cheeseBoost){
            if (horizontalSpeed > 0){
                //screams why isnt it working
                horizontalSpeed += 1;
            }
            if (horizontalSpeed < 0){
                horizontalSpeed -= 1;
            }
            if (verticalSpeed > 0){
                verticalSpeed += 1;
            }
            if (verticalSpeed < 0){
                verticalSpeed -= 1;
            }

            boostTimer -= Time.deltaTime;

            if (boostTimer <= 0){
                boostTimer = 0;
                cheeseBoost = false;
            }
        }


        // Normalized causes cheese boosted speed and non cheese boosted speed to normalize to the same
        // Now cheese boosted speed diagonal is same as normal diagonal but cheese boosted movement in general
        // is faster than normal movement.

        rigidBody.velocity = new Vector2(horizontalSpeed, verticalSpeed) * speed;
        if (horizontalSpeed != 0 & verticalSpeed != 0){
            if (cheeseBoost == false){
                rigidBody.velocity = new Vector2(horizontalSpeed, verticalSpeed).normalized * speed;
            } else {
                // normalized post creating new vector allows for speed to still be faster
                // but same as cheese boost speed is normally
                rigidBody.velocity = new Vector2(horizontalSpeed, verticalSpeed) * (speed / Mathf.Sqrt(2));
            }
        }


        Vector3 scale = transform.localScale;
        if (horizontalSpeed > 0) {
            scale.x = -1;
        } else if (horizontalSpeed < 0) {
            scale.x = 1;
        }
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        // Check if the object that entered is cheese
        if (other.CompareTag("Cheese"))
        {
            // Destroy this cheese object
            Destroy(other.gameObject);
            cheeseBoost = true;
            boostTimer = 1;
        }
    }
}
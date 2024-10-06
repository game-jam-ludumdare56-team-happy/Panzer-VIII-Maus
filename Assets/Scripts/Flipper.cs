using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    float horizontalSpeed;
    void Update()
    {
        horizontalSpeed = Input.GetAxisRaw("Horizontal");
        Vector3 scale = transform.localScale;
        if (horizontalSpeed > 0) {
            scale.x = -1;
        } else if (horizontalSpeed < 0) {
            scale.x = 1;
        }
        transform.localScale = scale;
    }
}
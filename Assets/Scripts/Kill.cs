using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private void OnCollision(Collision collision) {
        Destroy(collision.gameObject);
    }
}

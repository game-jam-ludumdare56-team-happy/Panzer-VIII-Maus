using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AntMovement : MonoBehaviour {
    public Transform target;
    public float speed = 3f;

    // Update is called once per frame
    void Update() {
        if ((target.transform.position.y) < (transform.position.y + 1f) & 
            (target.transform.position.y) > (transform.position.y - 1f)) {
        }
        
        Vector3 scale = transform.localScale;
        if ((target.transform.position.x) > (transform.position.x)) {
            scale.x = 1;
            transform.localScale = scale;
        } else {
            scale.x = -1;
            transform.localScale = scale;
        }


        if (target != null) {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
}
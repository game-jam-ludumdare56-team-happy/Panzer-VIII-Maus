using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oribital : MonoBehaviour
{
    public float oribitSpeed;
    public float spinSpeed;
    [SerializeField] private Transform mouse;
    void Update()
    {
        this.transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);
        this.transform.RotateAround(mouse.position, Vector3.forward, spinSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed;
    //public float rotationSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        //float horizontalInput = Input.GetAxis("Horizontal") --> get key input for A & D (left right)
        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
        //transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
    }
}

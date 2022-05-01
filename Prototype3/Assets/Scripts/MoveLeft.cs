using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 20;
    //private float speed = 20 --> set the speed for moving left
    private PlayerController playerControllerScript;
    //private PlayerController playerControllerScript --> reference to the playercontroller script
    private float leftBound = -15;
    //private float leftBound = -15 --> set the bounding area for moving left
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerConttoller>(); --> find the "Player" game object and get it's PlayerController script
    }

    // Update is called once per frame
    void Update()
    {
        //if(playerControllerScript.gameOver == false) --> get the gameover variable from playercontroller script and if its false...
        if(playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            //transform.Translate(Vector3.left * Time.deltaTime * speed) --> position of object to keep moving left
        }
        //If(transform.position.x < leftBound && gameObject.CompareTag("Obstacle") --> if position is less then leftBound and game object is Obstacle
        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            //Destroy(gameObject)
            Destroy(gameObject);
        }
        
    }
}

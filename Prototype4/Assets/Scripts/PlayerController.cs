using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private GameObject focalPoint;
    public bool hasPoweredUp;
    private float powerUpStrength = 15.0f;
    public GameObject powerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb = GetComponent<Rigidbody>(); --> get rigid body component from player game object and set as playerRb
        focalPoint = GameObject.Find("Focal Point");
        //focalPoint = GameObject.Find("Focal Point") --> find game object named Focal Point and set as focal point
        Debug.Log(playerRb);
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        //float forwardInput  = Input.GetAxis("Vertical"); --> add vertical input trigger
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        //playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput); --> add force to rigid body component (player) force towards/away from focal point * speed 
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
        //set power indicator's position to position of player + reduced y-axis position(so the indicator appears at the bottom of the player)
    }

    //private void OnTriggerEnter(Collider other) --> when game object enters/touches a trigger
    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Powerup") --> of the collider has a tag Powerup
        if (other.CompareTag("Powerup"))
        {
            hasPoweredUp = true;
            Destroy(other.gameObject);
            //Destroy(other.gameObject) --> destroy powerup if collider triggers
            StartCoroutine(PowerUpCountdownRoutine());
            //StartCoroutine(PowerUpCountdownRoutine()); --> start duration for powerup
            powerupIndicator.gameObject.SetActive(true);
            //set whether power indicator to "show"
        }
    }

    //private void OnCollisionEnter(Collision collision) --> when a gameobject collides with another
    private void OnCollisionEnter(Collision collision)
    {
        //If (collision.gameObject.CompareTag("Enemy") && hasPoweredUp --> if player colides with object tagged enemy and power up is active
        if (collision.gameObject.CompareTag("Enemy") && hasPoweredUp)
        {
            //Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>(); --> get the enemy game object rigidbody component
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            //Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position --> position away from player  = position of enemy - position of player
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            //enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse) --> add an impulse force to the rigid body component with magnitude of awayfromplayer * strength
            enemyRigidBody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            
        }
    }

    //IEnumerator PowerUpCountdownRoutine() --> enumerator interface for yield returns
    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        //yield return new WaitForSeconds(10) --> delay next action by 10 seconds
        hasPoweredUp = false;
        powerupIndicator.gameObject.SetActive(false);
        //disable power indicator 
    }
}

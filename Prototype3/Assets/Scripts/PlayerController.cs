using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    //private Rigidbody playerRB (rigidbody for player);
    public float jumpForce;
    //public float jumpForce;
    public float gravityModifier;
    //public float gravityModifier; 
    public bool onGround;
    //public bool onGround; detect whether player is touching the ground
    public bool gameOver = false;
    //public bool gameOver = false; --> initialise gameOver variable
    private Animator playerAnim;
    //private Animator playerAnim --> animator object initialized
    public ParticleSystem explosionParticle;
    //public ParticleSystem explosionParticle --> ParticleSystem object is to be added in editor
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    //public AudioClip jumpSound --> Audio clip object to be added in editor
    public AudioClip crashSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        //playerRb = GetComponent<Rigidbody>(); initialize rigidbody for player
        Physics.gravity *= gravityModifier;
        //Physics.gravity *= gravityModifier; multiply gravity by an amount set by gravity modifier(allows custom gravity value)
        playerAnim = GetComponent<Animator>();
        //playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        //playerAudio = GetComponent<AudioSource>(); --> set playerAudio to AudioSource component(make sure this component is added to the player)

    }

    // Update is called once per frame
    void Update()
    {
        //If (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver -> if space key pressed and player is on the ground and is not gameover
        if (Input.GetKeyDown(KeyCode.Space) && onGround && !gameOver)
            
        {

            playerAudio.PlayOneShot(jumpSound, 1.0f);
            //playerAudio.PlayOneShot(jumpSound, 1.0f); --> play jump sound when space is pressed (clip, volume scale)
            dirtParticle.Stop();
            //dirtParticle.Stop(); --> stop running particle 
            playerAnim.SetTrigger("Jump_trig");
            //playerAnim.SetTrigger("Jump_trig") --> trigger jump animation
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            //playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); add an impulse force(a short burst force) to the player rigidbody)
            onGround = false;
            //if jump then set onGround = false
        }
    }

    //private void OnCollisionEnter(Collision collision) -> OnCollisionEnter is called when this collider/rigidbody has begun touching another rigidbody/collider.
    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.CompareTag("Ground") --> if collide detected with object tagged "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            //dirtParticle.Play() --> play dirt particle while character is touching the ground
            dirtParticle.Play();
            // set player onGround as true
            onGround = true;

          //else if (collision.gameObject.CompareTag("Obstacle") --> if colide with an object tagged "Obstacle")
        } else if (collision.gameObject.CompareTag("Obstacle"))
        {

            playerAudio.PlayOneShot(crashSound, 1.0f);
            //playerAudio.PlayOneShot(crashSound, 1.0f) --> play crash sound
            explosionParticle.Play();
            dirtParticle.Stop();
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            //playerAnim.SetBool("Death_b", true); --> set whether death is triggered or not
            playerAnim.SetInteger("DeathType_int", 1);
            //playerAnim.SetInteger("DeathType_int", 1) --> set animation type for death
        }
        
    }
}

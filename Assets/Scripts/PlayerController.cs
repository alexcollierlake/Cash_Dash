using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

/**********
 * 
 * This script is a component of the player and controls
 * the movement based on player input
 * 
 * October 17, 2023
 * Alexandra Collier-Lake
 * 
 ***********/


public class PlayerController : MonoBehaviour
{

    [SerializeField] private float jumpForce, gravityModifier;
    [SerializeField] private ParticleSystem explosionParticle, dirtParticle;
    [SerializeField] private AudioClip jumpSound, crashSound;
    [SerializeField] private TextMeshProUGUI gameOver;

    private Animator playerAnimator;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private bool isOnGround;
    private AudioSource gameAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        isOnGround = true;
        Physics.gravity *= gravityModifier;
        playerAnimator = GetComponent<Animator>();
        gameAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnJump(InputValue input)
    {
        if(isOnGround && !GameManager.gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            gameAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();

        }
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Ground")
        {
            isOnGround = true;
            dirtParticle.Play();

        }
        else if (col.gameObject.tag == "Obstacle")
        {

            GameManager.gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            gameAudio.PlayOneShot(crashSound, 1.0f);
            explosionParticle.Play();
            dirtParticle.Stop();
            gameOver.gameObject.SetActive(true);
            

        }

      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Scoreable")
        {
            GameManager.ChangeScore(10);
        }

        if (other.gameObject.CompareTag("Coffee"))
        {
            // Sends speed of coffee into timer
            StartCoroutine(timer(25.0f, other.gameObject));
        }

        if (other.gameObject.CompareTag("Decaf"))
        {
            // Sends speed of decaf coffee into timer
            StartCoroutine(timer(10, other.gameObject));
        }
    }

    //starts timer countdown after collision with any coffee
    IEnumerator timer(float speed, GameObject coffee)
    {
        MoveLeft.speed = speed;
        Destroy(coffee);
        // do somethinng befroe timer starts
        yield return new WaitForSeconds(5);
        // do something after timer is dlne
        MoveLeft.speed = 15.0f;
    }
}

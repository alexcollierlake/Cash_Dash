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
    [SerializeField] private AudioClip coffee, decaf;

    private Animator playerAnimator;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private bool isOnGround;
    private AudioSource gameAudio;
    public static float playerSpeed { get; private set; }

    private void Awake()
    {
        playerSpeed = 15;
    }

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
            StartCoroutine(timer(20.0f, other.gameObject));
            gameAudio.PlayOneShot(coffee, 1.0f);
        }

        if (other.gameObject.CompareTag("Decaf"))
        {
            Debug.Log("is this working?");
            StartCoroutine(timer(10.0f, other.gameObject));
            gameAudio.PlayOneShot(decaf, 1.0f);
        }
    }

    //starts timer on colision
    IEnumerator timer(float speed, GameObject coffee)
    {

        Debug.Log("is this working?");
        playerSpeed = speed;
        Destroy(coffee);
        //do stuff before timer starts
        yield return new WaitForSeconds(5);
        //do stuff after timer ends
        playerSpeed = 15.0f;
    }
}

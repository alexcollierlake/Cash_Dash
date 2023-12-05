using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********
 * 
 * This script is a component of backround and the obstacles,
 * and moves them left to simulate the player running.
 * 
 * October 30, 2023
 * Alexandra Collier-Lake
 * 
 ***********/

public class MoveLeft : MonoBehaviour
{
    private float speed, leftBound;
    

    [SerializeField] private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        speed = 15.0f;
        leftBound = -15.0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (!GameManager.gameOver)
        {
            transform.Translate(Time.deltaTime * speed * direction);
        }

        destroyOutOfScene();

    }

    //idk wat this does
    private void destroyOutOfScene()
    {
        if(gameObject.transform.position.x < leftBound && gameObject.tag == "Obstacle")
        {
            Destroy(gameObject);
        }
    }

    //detects if collision with coffee
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coffee"))
        {
            // Sends speed of coffee into timer
            StartCoroutine(timer(25));
        }

        if (other.gameObject.CompareTag("Decaf"))
        {
            // Sends speed of decaf coffee into timer
            StartCoroutine(timer(5));
        }
    }

    //starts timer countdown after collision with any coffee
    IEnumerator timer(float speed)
    {
        this.speed = speed = 25.0f;
        // do somethinng befroe timer starts
        yield return new WaitForSeconds(5);
        // do something after timer is dlne
        speed = 15.0f;
    }
}

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
    private float leftBound;
    private float speed;
    

    [SerializeField] private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        speed = PlayerController.playerSpeed;
        leftBound = -15.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = PlayerController.playerSpeed;

        if (!GameManager.gameOver)
        {
            transform.Translate(Time.deltaTime * speed * direction);
        }

        destroyOutOfScene();

    }

    private void destroyOutOfScene()
    {
        if(gameObject.transform.position.x < leftBound && gameObject.tag == "Obstacle" )
        {
            Destroy(gameObject);
        }

        if(gameObject.transform.position.x < leftBound && gameObject.tag == "Decaf")
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.x < leftBound && gameObject.tag == "Coffee")
        {
            Destroy(gameObject);
        }

        if (gameObject.transform.position.x < leftBound && gameObject.tag == "Scoreable")
        {
            Destroy(gameObject);
        }
    }

}

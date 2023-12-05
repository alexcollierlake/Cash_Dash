using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********
 * 
 * This script is a component of backround, obstacles, and coffee
 * and moves them left to simulate the player running.
 * 
 * October 30, 2023
 * Alexandra Collier-Lake
 * 
 ***********/

public class MoveLeft : MonoBehaviour
{
    public static float speed { private get; set; }
    private float leftBound;
    

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
}

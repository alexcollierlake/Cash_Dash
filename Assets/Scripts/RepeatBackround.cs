using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********
 * 
 * This script is a component of the backround and 
 * repeats the backround as it moves left to simulate 
 * an infinite run.
 * 
 * October 30, 2023
 * Alexandra Collier-Lake
 * 
 ***********/

public class RepeatBackround : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        


    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < startPos.x - repeatWidth)
        {
            gameObject.transform.position = startPos;
        }
    }
}

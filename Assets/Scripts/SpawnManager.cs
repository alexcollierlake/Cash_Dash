using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**********
 * 
 * This script is a component of the spawnManager and 
 * spawns obsacles in front of the player periodically.
 * 
 * October 30, 2023
 * Alexandra Collier-Lake
 * 
 ***********/

public class SpawnManager : MonoBehaviour
{
    [Header("Obstacle Spawn Fields")]
    [SerializeField] private GameObject obstaclePrefab;

    
    private Vector3 spawnPos;
    private float startDelay, repeatRate;

    [Header("Collectable Spawn Fields")]
    [SerializeField]  private int nothing;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = new Vector3(25, 0, 0);
        startDelay = 5.0f;
        repeatRate = 2.0f;
        

        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);

        
    }

    private void Update()
    {
        SpawnCollectable();
    }

    private void SpawnObstacle()
    {
        if(!GameManager.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        else
        {
            CancelInvoke();
        }
        
    }

    private void SpawnCollectable()
    {
        // spaws randomly 
    }
}

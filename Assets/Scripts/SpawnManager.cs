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
    [SerializeField] private GameObject coffeePrefab;
    [SerializeField] private GameObject decafCoffeePrefab;


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
        InvokeRepeating("SpawnCollectable", startDelay + 1, repeatRate + 1);

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
        int randomCollectable = Random.Range(0, 2); // 0 for regular coffee, 1 for decaf coffee
        float randomHeight = Random.Range(0.0f, 3.0f); 
        Vector3 collectableSpawnPos = new Vector3(spawnPos.x, randomHeight, spawnPos.z);

        if (!GameManager.gameOver)
        {
            if (randomCollectable == 0)
            {
                Instantiate(coffeePrefab, collectableSpawnPos, coffeePrefab.transform.rotation);
            }
            else
            {
                Instantiate(decafCoffeePrefab, collectableSpawnPos, decafCoffeePrefab.transform.rotation);
            }
        }
        else
        {
            CancelInvoke();
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySound : MonoBehaviour
{
    private AudioSource moneyAudio;

    // Start is called before the first frame update
    void Start()
    {
        moneyAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            moneyAudio.Play();
            
        }
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashController : MonoBehaviour
{
    public bool pocketed { private get; set; }


    // Update is called once per frame
    void Update()
    {
        if(pocketed)
        {
            pocketed = false;          // Prevents multiple calls to InvokeRepeating
            InvokeRepeating("CashedIn", 0, 0.05f);
        }
    }

    private void CashedIn()
    {
        transform.localScale *= 0.9f;
    }
}

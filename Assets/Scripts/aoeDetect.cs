using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoeDetect : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "melts")
        {
            icicleFade.fading = true;
            Debug.Log("melts");
        }
    }

}

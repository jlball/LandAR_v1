using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class padRefuel : MonoBehaviour {

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<LanderControl>())
        {
            other.gameObject.GetComponent<LanderControl>().fuel = 100.0f;
        }
    }
}

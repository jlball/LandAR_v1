using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateDish : MonoBehaviour {

    public float rotationRate = 36.0f;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, rotationRate * Time.deltaTime, 0));
	}
}

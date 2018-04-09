using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanderControl : MonoBehaviour {

    private Rigidbody rb;
    public float thrusterForce = 1.0f;
    public float rotationSpeed = 36.0f;
    public VirtualJoystick joystick;
    public bool firingThruster = false;
    public float fuel = 100.0f;
    public float fuelBurnRate = 10.0f;
    public Slider fuelMeter;
    public float lerpT = 0.5f;

	void Start () 
    {
        rb = GetComponent<Rigidbody>();
	}
	
	void Update () 
    {
        rb.transform.Rotate(joystick.joystickVector() * rotationSpeed * Time.deltaTime);

        if(firingThruster && (fuel > 0))
        {
            rb.AddRelativeForce(-Vector3.forward * thrusterForce, ForceMode.Force);

            fuel = fuel - (fuelBurnRate * Time.deltaTime);
            //Debug.Log(fuel);
            fuelMeter.value = fuel;
        }
	}
}

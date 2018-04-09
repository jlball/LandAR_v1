using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

public class SetupPlanet : MonoBehaviour {

    public GameObject cameraPos;
    public float offset = 1.0f;
    public GameObject setupCanvas;
    public GameObject flightCanvas;
    public float lerpT = 0.3f;
    public GameObject lander;

    //References to be set on the lander upon instantiation
    public VirtualJoystick vJoystick;
    public Slider fuelMeter;
    public FireThruster fireThruster;


    private Material material;
    private Color currentColor;
    private bool planentLocked = false;
    private Vector3 landerPosRelCamera;


	void Start () {
        material = GetComponent<MeshRenderer>().material;
        currentColor = new Color(material.color.r, material.color.g, material.color.b, material.color.a);
        currentColor.a = 0.2f;
        material.color = currentColor;
	}
	
	void Update () {
        if (!planentLocked)
        {
            landerPosRelCamera = cameraPos.transform.TransformPoint(new Vector3(cameraPos.transform.localPosition.x, cameraPos.transform.localPosition.y, cameraPos.transform.localPosition.z + offset));
            transform.position = Vector3.Lerp(transform.position, landerPosRelCamera, lerpT);
            transform.rotation = cameraPos.transform.rotation;
        }
	}

    public void LockPlanetLocation()
    {
        planentLocked = true;
        currentColor.a = 1.0f;
        material.color = currentColor;

        setupCanvas.SetActive(false);
        flightCanvas.SetActive(true);

        Transform polarPad = transform.GetChild(0);
        Vector3 spawnPosition = transform.TransformPoint(new Vector3(polarPad.localPosition.x, polarPad.localPosition.y + 0.2f, polarPad.localPosition.z));
        GameObject landerInstantiated = Instantiate(lander, spawnPosition, transform.rotation);
        landerInstantiated.transform.Rotate(new Vector3(90, 0, 0));

        //Setting up the lander so it can be controlled / use gravity
        landerInstantiated.GetComponent<Gravity>().rbAttractor = GetComponent<Rigidbody>();
        landerInstantiated.GetComponent<LanderControl>().joystick = vJoystick;
        landerInstantiated.GetComponent<LanderControl>().fuelMeter = fuelMeter;
        fireThruster.lc = landerInstantiated.GetComponent<LanderControl>();

    }
}

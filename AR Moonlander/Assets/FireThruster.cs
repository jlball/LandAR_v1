using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireThruster : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    public LanderControl lc;

    public virtual void OnPointerDown(PointerEventData ped)
    {
        //Debug.Log("DOWN");
        lc.firingThruster = true;
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        //Debug.Log("UP");
        lc.firingThruster = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuelMeterColorIndicator : MonoBehaviour {

    public Image image;
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();
    }


	void Update () {
        if ((slider.value / slider.maxValue) < 0.5)
        {
            if ((slider.value / slider.maxValue) < 0.2)
            {
                image.color = Color.red;
            } else {
                image.color = Color.yellow;
            }
        }
        if (slider.value <= 0)
        {
            slider.gameObject.SetActive(false);
        }



	}
}

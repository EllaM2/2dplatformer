using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    public Gradient lightBar;
    public GameObject capsule;
    public Text display;
    public Slider lightSlider;

    public static float maxLight = 50;
    public float currentLight;

    // Start is called before the first frame update
    void Start()
    {
        currentLight = 0;
        SetGradient();
    }

    public void AddLight()
    {
        currentLight += 2;

        if (currentLight > maxLight)
        {
            currentLight = maxLight;
        }
        SetGradient();
        Debug.Log("Light = " + currentLight);
    }

    public void RemoveLight()
    {
        currentLight -= 2;

        if (currentLight < 0)
        {
            currentLight = 0;
        }
        SetGradient();
        Debug.Log("Light = " + currentLight);
    }

    public void AddSubSlider()
    {
       if (lightSlider.value < currentLight)
        {
            RemoveLight();
        }
       else if (lightSlider.value > currentLight) 
        {
            AddLight();
        }

  
    }

    private void SetGradient()
    {
        float lightpercent = currentLight / maxLight;
        Color percentColor = lightBar.Evaluate(lightpercent);

        capsule.GetComponent<SpriteRenderer>().material.color = percentColor;
        Debug.Log("percent = " + lightpercent);

       
        display.color = percentColor;
    }
}

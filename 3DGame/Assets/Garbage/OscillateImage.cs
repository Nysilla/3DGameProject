using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OscillateImage : MonoBehaviour
{
    public Sprite[] sprite = new Sprite[2];
    public float Delay;
    float nextTimeToFire;
    int i = 0;

    void Update()
    {
        if (nextTimeToFire <= Time.realtimeSinceStartup)
        {
            nextTimeToFire = Time.realtimeSinceStartup + Delay;
            GetComponent<Image>().sprite = sprite[i%2];
            i++;
        }
    }
}

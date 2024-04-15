using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    public float Seconds;
    void Start()
    {
        Invoke("SewerSlide", Seconds);
    }

    void SewerSlide()
    {
        Destroy(gameObject);
    }
}

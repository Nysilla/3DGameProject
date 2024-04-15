using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthIndicator : MonoBehaviour
{
    public Image image;
    public PlayerHealth playerHealth;
    void Update()
    {
        image.color = new Color(1, 1, 1, 1 - (playerHealth.health/100));
    }
}

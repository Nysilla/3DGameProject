using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTower : MonoBehaviour
{
    public float HealRadius;
    public float HealDelay;
    float nextTimeToFire;
    public Transform Sphere;
    void Update()
    {
        foreach (Collider c in Physics.OverlapSphere(transform.position, HealRadius))
        {
            if (c.CompareTag("Player"))
            {
                if (Time.time > nextTimeToFire)
                {
                    nextTimeToFire = Time.time + HealDelay;
                    if (Vector3.Distance(transform.position, c.transform.position) <= HealRadius && c.GetComponent<PlayerHealth>().health < c.GetComponent<PlayerHealth>().maxHealth)
                    {
                        c.GetComponent<PlayerHealth>().health += 1;
                    }
                }
                c.GetComponent<PlayerHealth>().BeingHealed = Vector3.Distance(transform.position, c.transform.position) <= HealRadius;
                Sphere.localScale = new Vector3(HealRadius * 2, HealRadius * 2, HealRadius * 2);
            }
        }
    }
}

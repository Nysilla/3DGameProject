using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTower : MonoBehaviour
{
    public float HealRadius;
    public Transform Player;
    public float HealDelay;
    float nextTimeToFire;
    public Transform Sphere;
    private void Start()
    {
        Player = GameObject.Find("Player").transform;
    }
    void Update()
    {
        if (Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + HealDelay;
            if (Vector3.Distance(transform.position, Player.position) <= HealRadius && Player.GetComponent<PlayerHealth>().health < Player.GetComponent<PlayerHealth>().maxHealth)
            {
                Player.GetComponent<PlayerHealth>().health += 1;
            }
        }
        Player.GetComponent<PlayerHealth>().BeingHealed = Vector3.Distance(transform.position, Player.position) <= HealRadius;
        Sphere.localScale = new Vector3(HealRadius * 2, HealRadius * 2, HealRadius * 2);
    }
}

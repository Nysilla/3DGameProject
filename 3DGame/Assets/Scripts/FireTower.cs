using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTower : MonoBehaviour
{
    public GameObject[] MobsToSummon;
    public float SummonDelay;
    float nextTimeToFire;
    public Transform Eye;
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 300f) { return; }
        if (Time.time > nextTimeToFire)
        {
            nextTimeToFire = Time.time + SummonDelay;
            Instantiate(MobsToSummon[Random.Range(0, MobsToSummon.Length)], Eye.position, Quaternion.identity);
        }
    }
}

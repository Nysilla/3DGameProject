using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireTower : MonoBehaviour
{
    public GameObject[] MobsToSummon;
    public float SummonDelay;
    float nextTimeToFire;
    public Transform Eye;
    public float ScalingByDeaths;

    private void Start()
    {
        Instantiate(MobsToSummon[Random.Range(0, MobsToSummon.Length)], Eye.position, Quaternion.identity);
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > VariableManager.Instance.MobCap) { return; }
        if (Time.time > nextTimeToFire && VariableManager.Instance.AnimalDeaths > 0)
        {
            Debug.Log(SummonDelay / Mathf.Pow(VariableManager.Instance.AnimalDeaths, ScalingByDeaths));
            nextTimeToFire = Time.time + (SummonDelay / Mathf.Pow(VariableManager.Instance.AnimalDeaths, ScalingByDeaths));
            Instantiate(MobsToSummon[Random.Range(0, MobsToSummon.Length)], Eye.position, Quaternion.identity);
        }
    }
}

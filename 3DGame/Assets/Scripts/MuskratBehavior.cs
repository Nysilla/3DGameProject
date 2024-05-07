using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuskratBehavior : MonoBehaviour
{
    public Transform Player;
    public float AttackDelay;
    public float Damage;
    float nextTimeToFire;
    private void Start()
    {
        Player = EnemyHealth.FindNearestPlayer(transform).transform;
    }

    void Update()
    {
        if (Time.time > nextTimeToFire && Vector3.Distance(transform.position, Player.position) < 1.5f)
        {
            nextTimeToFire = Time.time + AttackDelay;
            Player.GetComponent<PlayerHealth>().health -= Damage;
        }
    }
}

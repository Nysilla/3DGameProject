using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public TextMeshPro TMP;
    public NavMeshAgent agent;
    public GameObject DeathParticles;
    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(DeathParticles, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (agent == null) { return; }
        agent.destination = GameObject.Find("Player").transform.position;
        if (TMP == null) { return; }
        TMP.text = health.ToString();
    }
}

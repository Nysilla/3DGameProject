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
    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (agent == null) { return; }
        agent.destination = GameObject.Find("Player").transform.position;
        TMP.text = health.ToString();
    }
}

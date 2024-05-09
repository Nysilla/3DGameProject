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
    public float Targeted;
    public int MoneyValue;
    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(DeathParticles, transform.position, Quaternion.identity);
            FindNearestPlayer(transform).GetComponent<PlayerHealth>().Money += MoneyValue;
            VariableManager.Instance.AnimalDeaths++;
            Destroy(gameObject);
        }
        if (agent == null) { return; }
        agent.destination = FindNearestPlayer(transform).transform.position;
        if (TMP == null) { return; }
        TMP.text = health.ToString();
    }

    public static GameObject FindNearestPlayer(Transform origin)
    {
        float distance = 0;
        GameObject playerTemp = null;
        foreach (GameObject g in GameObject.FindGameObjectsWithTag("Player"))
        {
            if (Vector3.Distance(origin.position, g.transform.position) < distance || distance == 0)
            {
                distance = Vector3.Distance(origin.position, g.transform.position);
                playerTemp = g;
            }
        }
        return playerTemp;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float Damage;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            collision.transform.GetComponent<EnemyHealth>().health -= Damage;
        }
        if (collision.transform.CompareTag("Projectile")) { return; }
        Destroy(gameObject);
    }
}

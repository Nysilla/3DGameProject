using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTower : MonoBehaviour
{
    public Transform Target;
    public float AttackRadius;
    public Transform Cannon;
    public GameObject CannonBall;
    public float AttackDelay;
    public float ProjectileSpeed;
    float nextTimeToFire;
    bool Targeted;
    void Update()
    {
        if(Target == null)
        {
            foreach (Collider t in Physics.OverlapSphere(transform.position, AttackRadius))
            {
                if (t.transform.CompareTag("Enemy"))
                {
                    if (t.transform.GetComponent<EnemyHealth>().Targeted < 2)
                    {
                        Target = t.transform;
                        return;
                    }
                }
            }
        }
        else
        {
            if(Vector3.Distance(transform.position, Target.position) < AttackRadius && Targeted == true)
            {
                Target.GetComponent<EnemyHealth>().Targeted -= 1;
                Targeted = false;
                Target = null; return;
            }
            else if(Targeted == false)
            {
                Targeted = true;
                Target.GetComponent<EnemyHealth>().Targeted += 1;
            }
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + AttackDelay;
                GameObject temp = Instantiate(CannonBall, Cannon.position, Quaternion.identity);
                temp.GetComponent<Rigidbody>().velocity = Cannon.forward * ProjectileSpeed;
            }
            Cannon.LookAt(Target.position + (Vector3.up*0.5f));
        }

    }
}

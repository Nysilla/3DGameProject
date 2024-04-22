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
    bool FirstShot = true;
    void Update()
    {
        if(Target == null)
        {
            FirstShot = true;
            foreach (Collider t in Physics.OverlapSphere(transform.position, AttackRadius))
            {
                if (t.transform.CompareTag("Enemy"))
                {
                    Target = t.transform;
                    return;
                }
            }
        }
        else
        {
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + AttackDelay;
                if (FirstShot)
                {
                    FirstShot = false;
                    return;
                }
                GameObject temp = Instantiate(CannonBall, Cannon.position, Quaternion.identity);
                temp.GetComponent<Rigidbody>().velocity = Cannon.forward * ProjectileSpeed;
            }
            Cannon.LookAt(Target.position + (Vector3.up*0.5f));
        }

    }
}

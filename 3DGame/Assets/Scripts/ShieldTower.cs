using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldTower : MonoBehaviour
{
    public float Radius;
    public float Speed;
    public Transform Sphere;
    void FixedUpdate()
    {
        Sphere.localScale = new Vector3(Radius*2, Radius*2, Radius*2);
        foreach (Collider t in Physics.OverlapSphere(transform.position, Radius))
        {
            if (t.CompareTag("Enemy"))
            {
                t.GetComponent<Rigidbody>().velocity = (t.transform.position - transform.position) * Speed;
            }
        }
    }
}

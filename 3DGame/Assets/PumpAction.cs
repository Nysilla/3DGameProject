using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpAction : MonoBehaviour
{
    public Transform ShootingPoint;
    public int Pellets = 10;
    public float Scatter;
    public float Damage;
    public LayerMask PlayerMask;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            for (int i = 0; i < Pellets; i++)
            {
                RaycastHit ray;
                if (Physics.Raycast(ShootingPoint.position, -ShootingPoint.forward + new Vector3(Random.Range(-Scatter, Scatter), Random.Range(-Scatter, Scatter), Random.Range(-Scatter, Scatter)), out ray, 1000, ~PlayerMask))
                {
                    if (ray.transform.CompareTag("Enemy"))
                    {
                        ray.transform.GetComponent<EnemyHealth>().health -= Damage;
                    }
                    Debug.DrawLine(ShootingPoint.position, ray.point);
                }
            }
        }
    }
}

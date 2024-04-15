using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpAction : MonoBehaviour
{
    public Transform ShootingPoint;
    public GameObject bullet;
    public GameObject bullet_hit;
    public GameObject Decal;
    public ParticleSystem ps;
    
    public float BulletSpeed;
    public int Pellets = 10;
    public float Scatter;
    public float Damage;
    public LayerMask PlayerMask;
    public AudioSource AudioSource1;
    public AudioSource AudioSource2;

    public float AttackDelay;
    float nextTimeToFire;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + AttackDelay;
                AudioSource1.PlayOneShot(AudioSource1.clip);
                Delay();
                ps.Play();
                GetComponent<Animator>().Play("Fire");
                for (int i = 0; i < Pellets; i++)
                {
                    RaycastHit ray;
                    Vector3 ShootingDirection = -ShootingPoint.forward + new Vector3(Random.Range(-Scatter, Scatter), Random.Range(-Scatter, Scatter), Random.Range(-Scatter, Scatter));
                    if (Physics.Raycast(ShootingPoint.position, ShootingDirection, out ray, 1000, ~PlayerMask))
                    {
                        GameObject temp = Instantiate(bullet, ShootingPoint.position, Quaternion.identity);
                        temp.GetComponent<Rigidbody>().velocity = ShootingDirection * BulletSpeed;
                        if (ray.transform.CompareTag("Enemy"))
                        {
                            GameObject temp2 = Instantiate(bullet_hit, ray.point, Quaternion.FromToRotation(Vector3.forward, ray.normal));
                            temp2.transform.parent = ray.transform;
                            if (Random.Range(0, 3) == 0)
                            {
                                GameObject temp3 = Instantiate(Decal, ray.point, Quaternion.FromToRotation(Vector3.forward, ray.normal));
                                temp3.transform.parent = ray.transform;
                            }
                            ray.transform.GetComponent<EnemyHealth>().health -= Damage;
                        }
                    }
                }
            }
        }
    }
    void Delay()
    {
        AudioSource2.PlayOneShot(AudioSource2.clip);
    }
}

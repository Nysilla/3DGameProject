using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SparrowBehavior : MonoBehaviour
{
    public Transform Player;
    public Rigidbody rb;
    public float speed;
    public Animator animator;
    public float AttackDelay;
    public float AttackSpeed;
    public float damage;
    float nextTimeToFire;
    float nextTimeToFire1;
    private void Start()
    {
        Player = EnemyHealth.FindNearestPlayer(transform).transform;
        animator.SetBool("FlyingCuzAttack", true);
    }

    private void FixedUpdate()
    {
        transform.LookAt(Player);
    }

    void Update()
    {
        Vector3 direction = EnemyHealth.FindNearestPlayer(transform).transform.position - transform.position;
        transform.LookAt(Player.position);
        float distance = Vector3.Distance(transform.position, Player.position);
        if (distance > 20) { return; }
        if (distance < 3)
        {
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + AttackDelay;
                StartCoroutine(Attack(direction, distance));
            }
            return;
        }
        rb.velocity = direction.normalized * speed;
    }

    IEnumerator Attack(Vector3 direction, float distance)
    {
        yield return new WaitForEndOfFrame();
        rb.velocity = direction.normalized * AttackSpeed;
        Player.GetComponent<PlayerHealth>().health -= damage;
        yield return new WaitForSecondsRealtime(AttackDelay/2);
        rb.velocity = -direction.normalized * AttackSpeed * 0.8f;
    }
}

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
    private void Start()
    {
        Player = GameObject.Find("Player").transform;
        animator.SetBool("FlyingCuzAttack", true);
    }
    void Update()
    {
        Vector3 direction = Player.position - transform.position;
        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) < 3)
        {
            return;
        }
        rb.velocity = direction.normalized * speed;
    }
}

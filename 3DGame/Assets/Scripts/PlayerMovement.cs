using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    float DefaultSpeed;
    public float JumpSpeed;
    public Vector3 AddedVelocity;
    bool Jump;
    private void Start()
    {
        DefaultSpeed = speed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = DefaultSpeed * 2;
        }
        else
        {
            speed = DefaultSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump = true;
        }
    }
    private void FixedUpdate()
    {
        Vector3 moveDirection = (Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward)*speed;
        moveDirection.y = rb.velocity.y;
        if (Jump)
        {
            Jump = false;
            moveDirection.y += JumpSpeed;
        }
        rb.velocity = moveDirection;
    }
}

using System;
using UnityEngine;

public class CocroachMovement : MonoBehaviour
{
    private float curJumpTime = 0;
    private const float maxJumpTime = 0.3f;

    private float moveSpeed = 10;
    private float jumpForce = 70;

    private Rigidbody rb;

    private bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 moveVec)
    {

        if (FloorChecker.CheckFloor(transform.position))
        {
            curJumpTime = 0;
            isJumping = false;
        }
        if(  (isJumping&& curJumpTime < maxJumpTime) || FloorChecker.CheckFloor(transform.position) )
        {
            isJumping = true;
            curJumpTime += Time.deltaTime;
        }
        else
        {
            moveVec.y = 0;
        }


        rb.AddForce(new Vector2(0, moveVec.y * jumpForce * Time.deltaTime), ForceMode.Impulse);
        moveVec.y = rb.velocity.y;
        moveVec.x *= moveSpeed;
        rb.velocity = moveVec;
    }
}

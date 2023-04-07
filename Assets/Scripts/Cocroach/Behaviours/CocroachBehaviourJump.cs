using UnityEngine;
using UnityEngine.InputSystem;

public class CocroachBehaviourJump : CocroachBehaviourRun
{
    private float curTime = 0f;
    private const float MaxTime = 0.3f;
    private const float jumpForce = 120f;
    private const float moveSpeed = 20;
    private float mass = 1;
    private const float friction = 20;
    private Rigidbody2D rb2 = new Rigidbody2D();
    public override void Enter()
    {
        curTime = 0;
        mass = rb.mass;
        //_animator.SetBool("Idle",true);
    }

    public override void Exit()
    {
        //_animator.SetBool("Jump",false);
    }

    public override void Update()
    {
        Vector2 moveDir = Vector2.zero;
        
        InputAction action = input.actions.FindAction("Move");
        moveDir = action.ReadValue<Vector2>();
        curTime += Time.deltaTime; 
        Debug.Log(CheckFloor());
        if (curTime > MaxTime || CheckFloor())
            moveDir.y = 0;
        
        rb.AddForce(new Vector2(0,mass*moveDir.y*jumpForce*Time.deltaTime),ForceMode2D.Impulse);
        moveDir.y = rb.velocity.y;
        moveDir.x *= moveSpeed ; 
        rb.velocity = moveDir;
    }

    private bool CheckFloor()
    {
        int layerMask = LayerMask.NameToLayer("Floor");
        
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, layerMask);
    }
}

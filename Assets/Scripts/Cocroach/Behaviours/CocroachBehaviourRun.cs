using UnityEngine;
using UnityEngine.InputSystem;

public class CocroachBehaviourRun : ICocroachBehaviour
{
    private const float moveSpeed = 20;

    public override void Enter()
    {
        //_animator.SetBool("Run",true);
    }

    public override void Exit()
    {
        //_animator.SetBool("Run",false);

    }

    public override void Update()
    {
        Vector2 moveDir = Vector2.zero;
        InputAction action = input.actions.FindAction("Move");
        moveDir = action.ReadValue<Vector2>();
        moveDir.y = rb.velocity.y;
        moveDir.x *= moveSpeed ; 
        rb.velocity = moveDir;
    }
}

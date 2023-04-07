using UnityEngine;

public class CocroachBehaviourIdle :ICocroachBehaviour
{
    public override void Enter()
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
    }

    public override void Exit()
    {
        //_animator.SetBool("Idle",false);
    }

    public override void Update()
    {
    }
    
}

using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CocroachMovement : MonoBehaviour
{
    private Dictionary<States, ICocroachBehaviour> _cocroachBehaviours = new Dictionary<States, ICocroachBehaviour>();
    private States curentBehaviour;

    public enum States 
    {
        Idle,
        Run,
        Jump
    }  
    
    private void Start()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        
        _cocroachBehaviours[States.Idle] = new CocroachBehaviourIdle();
        _cocroachBehaviours[States.Run] = new CocroachBehaviourRun();
        _cocroachBehaviours[States.Jump] = new CocroachBehaviourJump();
        Debug.Log(GetComponent<PlayerInput>());
        _cocroachBehaviours[States.Idle].Init(this);
        _cocroachBehaviours[States.Run].Init(this);
        _cocroachBehaviours[States.Jump].Init(this);
        

        curentBehaviour = States.Run;
    }

    void Update()
    {
        _cocroachBehaviours[curentBehaviour].Update();
        Debug.Log(curentBehaviour);
    }

    public void SetBehaviour(States behaviorType)
    {
        if(behaviorType == curentBehaviour) return;
        _cocroachBehaviours[curentBehaviour].Exit();
        curentBehaviour = behaviorType;
        _cocroachBehaviours[curentBehaviour].Enter();
        
    }
}

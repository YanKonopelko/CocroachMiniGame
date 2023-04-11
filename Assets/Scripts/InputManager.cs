using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    
    private CocroachMovement cocroach;
    private Transform cocroachTransform;
    private Rigidbody cocroachRb;
    
    private PlayerInput _input;

   
    void Start()
    {
        cocroach = FindObjectOfType<CocroachMovement>();
        _input = cocroach.GetComponent<PlayerInput>();
    }

    void Update()
    {
        Vector2 moveVec = _input.actions.FindAction("Move").ReadValue<Vector2>();
        
        cocroach.Move(moveVec);

    }

    
}

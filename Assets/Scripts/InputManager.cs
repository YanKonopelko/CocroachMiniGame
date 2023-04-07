using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private CocroachMovement cocroach;
    private PlayerInput _input;
    void Start()
    {
        cocroach = FindObjectOfType<CocroachMovement>();
        _input = cocroach.GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 a = _input.actions.FindAction("Move").ReadValue<Vector2>();
        if (a.y != 0)
            cocroach.SetBehaviour(CocroachMovement.States.Jump);
        else if( a.x !=0)
            cocroach.SetBehaviour(CocroachMovement.States.Run);
        else
            cocroach.SetBehaviour(CocroachMovement.States.Idle);
        if(_input.actions.FindAction("Pause").WasPressedThisFrame())
            MiniGameManager.instance.PauseGame();
    }
}

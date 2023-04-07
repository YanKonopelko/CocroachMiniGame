using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ICocroachBehaviour : MonoBehaviour
{
   protected CocroachMovement _cocroachMovement;
   protected PlayerInput input ;
   protected Rigidbody2D rb;
   protected Animator _animator;
   protected Transform _transform;
   protected BoxCollider2D coll;
   public abstract void Enter();
   public abstract void Exit();
   public abstract void Update();

   public void Init(CocroachMovement cocroachMovement)
   {
      _cocroachMovement = cocroachMovement;
      input = _cocroachMovement.GetComponent<PlayerInput>();
      rb = _cocroachMovement.GetComponent<Rigidbody2D>();
      _transform = _cocroachMovement.GetComponent<Transform>();
      coll = _cocroachMovement.GetComponent<BoxCollider2D>();
      //_animator = GetComponent<Animator>();
   }
}
using UnityEngine;

public class Tumbleweed : Obstacle
{
    private Transform _transform;
    [SerializeField] private float rotationSpeed = -50;
    [SerializeField] private float movementSpeed = -50;
    private Rigidbody rb;
    [SerializeField] private float size = 1;
    private void OnEnable()
    {
        _transform = transform;
        rb = GetComponent<Rigidbody>();
        transform.localScale = new Vector3(size,size,size);
    }


    private void Update()
    {
        _transform.Rotate(new Vector3(0,0,-1),Time.deltaTime*rotationSpeed);
        rb.velocity = new Vector2(movementSpeed,rb.velocity.y) ;
    }
    
}


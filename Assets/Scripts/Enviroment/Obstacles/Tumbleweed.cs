using UnityEngine;

public class Tumbleweed : Obstacle
{
    private Transform _transform;
    [SerializeField] private float rotationSpeed = -50;
    [SerializeField] private float movementSpeed = -50;
    private Rigidbody2D rb;
    [SerializeField] private float size = 1;
    private void OnEnable()
    {
        _transform = transform;
        rb = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(size,size,1);
    }


    private void Update()
    {
        _transform.Rotate(new Vector3(0,0,-1),Time.deltaTime*rotationSpeed);
        rb.velocity = new Vector2(movementSpeed,rb.velocity.y) ;
    }
    
}


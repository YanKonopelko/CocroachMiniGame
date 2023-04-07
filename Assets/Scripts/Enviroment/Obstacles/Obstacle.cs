using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.GetComponent<Cocroach>())
            col.gameObject.GetComponent<Cocroach>().Death();
    }
}

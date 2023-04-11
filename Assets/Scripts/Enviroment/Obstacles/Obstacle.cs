using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.GetComponent<Cocroach>())
            col.gameObject.GetComponent<Cocroach>().Death();
    }
}

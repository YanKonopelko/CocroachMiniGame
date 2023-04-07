using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform Cocroach;
    private Transform _transform;

    private void Start()
    {
        Cocroach = FindObjectOfType<CocroachMovement>().gameObject.transform;
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = _transform.position;
        if (!(Cocroach.position.x > _transform.position.x)) return;
        pos.x = Cocroach.position.x;
        transform.position = pos;

    }
}

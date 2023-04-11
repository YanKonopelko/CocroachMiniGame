using UnityEngine;

public class Tile : MonoBehaviour
{
    private TileManager _manager;
    public float length = 50;

    private void Start()
    {
        SetSpawner(transform.parent.GetComponent<TileManager>());
        var scale = transform.GetChild(0).transform.localScale;
        transform.GetChild(0).transform.localScale = new Vector3(length, scale.y, scale.z);
    }

    public void SetSpawner(TileManager manager)
    {
        _manager = manager;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            _manager.Spawn(1, this);
            Destroy(this);
        }
    }
}

using UnityEngine;

public class Tile : MonoBehaviour
{
    private TileManager _manager;
    public float length = 50;

    private void Start()
    {
        SetSpawner(transform.parent.GetComponent<TileManager>());
    }

    public void SetSpawner(TileManager manager)
    {
        _manager = manager;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
            _manager.Spawn(1,this);
    }
}

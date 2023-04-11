using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [HideInInspector]
    public int arrayIdx = 0;
    [HideInInspector]
    public string[] ObstacleType = { "THORNS", "TUMBLEWEED"};
    
    [SerializeField] private Obstacle[] _obstaclesPrefabs;
    

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
            Spawn();
    }

    private void Spawn()    
    {
        transform.position += new Vector3(50,0,0);
        var a =Instantiate(_obstaclesPrefabs[arrayIdx], transform.position,Quaternion.identity);
        a.transform.parent = transform.parent;
        Destroy(gameObject);
    }
}

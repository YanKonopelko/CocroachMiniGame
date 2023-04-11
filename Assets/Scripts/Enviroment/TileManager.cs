using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tile[] _tilePrefabs;

    private List<Tile> spawnedTiles = new List<Tile>();

    private void OnEnable()
    {
        MiniGameManager.instance.onGameStart += StartSpawn;
    }
    private void OnDisable()
    {
        MiniGameManager.instance.onGameStart -= StartSpawn;
    }
    private void StartSpawn()
    {
        var newTile = Instantiate(_tilePrefabs[0],Vector2.zero,Quaternion.identity);
        newTile.transform.parent = transform;
        newTile.SetSpawner(this);
        AddTile(newTile);
    }
    public void Spawn(int num,Tile curTile)
    {
        Vector2 spawnPoint = curTile.transform.position;
        spawnPoint += new Vector2(curTile.length/2 + _tilePrefabs[num].length/2 ,0);
        
        var newTile = Instantiate(_tilePrefabs[num],spawnPoint,Quaternion.identity);
        newTile.transform.parent = transform;
        newTile.SetSpawner(this);
        
        AddTile(newTile);
        
        if(spawnedTiles.Count>7)
            RemoveFirstTile();
    }

    private void AddTile(Tile tile)
    {
        spawnedTiles.Add(tile);
    }

    private void RemoveFirstTile()
    {
        spawnedTiles.Remove(spawnedTiles[0]);
    }
}

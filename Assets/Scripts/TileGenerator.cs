using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private ItemGenerator itemGenerator;
    private TileRepository tileParams;
  
    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPos = 0;
    private float tileLength = 100f;
    private Transform player;
    private int startTiles = 5;

    private int tilesCount = 0;

    public Action<int> OnTouchCoin;
    public Action<int> OnTouchEnemy;
    public Action<int> OnNextTile;

    void Update()
    {
        if (player.position.z - 60 > spawnPos - (startTiles * tileLength))
        {
            SpawnTile(UnityEngine.Random.Range(0, tileParams.tileList.Count));
            DeleteTile();
        }
    }

    public void Init(Transform _player, TileRepository tiles)
    {
        player = _player;
        tileParams = tiles;
       
        for (int i = 0; i < startTiles; i++)
        {
            SpawnTile(UnityEngine.Random.Range(0, tiles.tileList.Count));
        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(tileParams.tileList[tileIndex].tilePrefab, transform.forward * spawnPos, transform.rotation);
        TileFiller(nextTile);
        activeTiles.Add(nextTile);
        spawnPos += tileLength;
        tilesCount++;

        OnNextTile?.Invoke(tilesCount);
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private void TileFiller(GameObject nextTile)
    {
        List<Vector3> positions = new List<Vector3>();
        for (var i = 0; i < tileParams.coinSettings.nomber; i++)
        {
            itemGenerator.SpawnItem(tileParams.coinSettings, nextTile, positions,tileLength, OnCoinReaction);
        }
        for (var i = 0; i < tileParams.enemySettings.nomber; i++)
        {
          itemGenerator.SpawnItem(tileParams.enemySettings, nextTile, positions, tileLength, OnEnemyReaction);
        }
    }

    public void OnCoinReaction(int cost)
    {
        OnTouchCoin?.Invoke(cost);
    }
    public void OnEnemyReaction(int cost)
    {
        OnTouchEnemy?.Invoke(cost);
    }
   
}

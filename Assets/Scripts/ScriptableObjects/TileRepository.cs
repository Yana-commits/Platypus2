using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Repositories/TileRepository")]
public class TileRepository : ScriptableObject
{
   public List<Tiles> tileList;
   
    public ItemParams coinSettings;
    public ItemParams enemySettings;
}
[Serializable]
public class Tiles
{
    public GameObject tilePrefab;
}
[Serializable]
public class ItemParams
{
    public Items prefab;
    public int nomber;
    public int cost;
}

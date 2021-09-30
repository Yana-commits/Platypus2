using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public void SpawnItem(ItemParams itemParams, GameObject nextTile, List<Vector3> positions, float tileLength, Action<int> callback)
    {
        var item = Instantiate(itemParams.prefab) as Items;
        item.cost = itemParams.cost;
        item.OnTouch += callback;

        item.transform.SetParent(nextTile.transform);

        var itemPosition = FindPosition(positions, tileLength);
        item.transform.position = itemPosition + nextTile.transform.position - new Vector3(0, 0, tileLength / 2);
    }

    private Vector3 FindPosition(List<Vector3> positions, float tileLength)
    {
        float[] widePos = { -3, 0, 3 };
        float xPos = widePos[UnityEngine.Random.Range(0, widePos.Length)];
        float zPos = UnityEngine.Random.Range(1, tileLength - 1);

        Vector3 itemPosition = new Vector3((int)Math.Round(xPos), 1, (int)Math.Round(zPos));

        if (positions.Contains(itemPosition))
        {
            itemPosition += new Vector3Int(0, 0, 1);
        }
        else
        {
            positions.Add(itemPosition);
        }

        return itemPosition;
    }
}

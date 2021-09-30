using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ITouchable>(out var touchable))
        {
            touchable.Touch();
        }
    }
}

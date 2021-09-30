using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Items,ITouchable
{
   
    public void Touch()
    {
        OnTouch?.Invoke(cost);
        Destroy(gameObject);
    }
}

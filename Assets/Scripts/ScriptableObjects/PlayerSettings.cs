using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Repositories/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    public float speed;
   public float gravity;
   public float lineDistance;
}


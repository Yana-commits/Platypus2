using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;

    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
        transform.position = newPosition;
    }

    public void Init(Transform _player)
    {
        player = _player;
        offset = transform.position - player.position;
    }
}

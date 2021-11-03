using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;
    
    //private int lineToMove = 1;
    //private float lineDistance ;
    private float horizontalInput;

    public Animator animator;
    public float speed;

    private void Update()
    {
        //if (SwipeController.swipeRight)
        //{
        //    if (lineToMove < 2)
        //        lineToMove++;
        //}

        //if (SwipeController.swipeLeft)
        //{
        //    if (lineToMove > 0)
        //        lineToMove--;
        //}

        //Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        //if (lineToMove == 0)
        //    targetPosition += Vector3.left * lineDistance;
        //else if (lineToMove == 2)
        //    targetPosition += Vector3.right * lineDistance;

        //transform.position = targetPosition;
    }

    void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * 0.03f;
        rigidbody.MovePosition(rigidbody.position + forwardMove + horizontalMove);
    }
    private void GetDirection(Vector2 direction)
    {
        horizontalInput = direction.x;
    }

    public void Init(PlayerSettings settings)
    {
        SwipeDetection.SwipeEvent += GetDirection;
        speed = settings.speed;
        //lineDistance = settings.lineDistance;
    }
    private void OnDestroy()
    {
        SwipeDetection.SwipeEvent -= GetDirection;
    }
}

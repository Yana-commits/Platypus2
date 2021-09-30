using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Items, ITouchable
{
    [SerializeField] private GameController controller;

    public Animator animator;

    void Start()
    {
        controller.OnEnemy += ToDie;
    }
    private void ToDie()
    {
       
        animator.SetTrigger("Die");
    }
    public void Touch()
    {
        OnTouch?.Invoke(cost);
    }

    void OnDestroy()
    {
        controller.OnEnemy -= ToDie;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Items, ITouchable
{
    [SerializeField] private GameController controller;

    public Animator animator;

    void Start()
    {
        controller.OnHitEnemy += ToDie;
        controller.OnSubEnemy += ToHide;
    }
    private void ToDie()
    {
        animator.SetTrigger("Die");
    }
    private void ToHide()
    {
        Destroy(gameObject);
    }
    public void Touch()
    {
        OnTouch?.Invoke(cost);
    }

    void OnDestroy()
    {
        controller.OnHitEnemy -= ToDie;
        controller.OnSubEnemy -= ToHide;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePanel : MonoBehaviour
{
    [SerializeField] private Button subBt;
    [SerializeField] private Button hitBt;

    private int enemyCost;

    private Action callbackHit;
    private Action<int> callbackSub;

    private void OnEnable()
    {
        subBt.onClick.AddListener(SubCoin);
        hitBt.onClick.AddListener(HitEnemy);
    }

    public void InitPanel(int _enemyCost,int score, Action _callbackHit, Action<int> _callbackSub)
    {
        enemyCost = _enemyCost;
        callbackHit = _callbackHit;
        callbackSub = _callbackSub;

        if (score < enemyCost)
        {
            subBt.gameObject.SetActive(false);
        }
    }
    public void SubCoin()
    {
        callbackSub?.Invoke(enemyCost);
    }
    public void HitEnemy()
    {
        callbackHit?.Invoke();
        subBt.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        subBt.onClick.RemoveListener(SubCoin);
        hitBt.onClick.RemoveListener(HitEnemy);
    }
}

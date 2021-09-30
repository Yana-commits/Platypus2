using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Text costText;
    [SerializeField] private ChoosePanel panel;

    public Action OnDoHit;
    public Action<int> OnDoSub;

    public void SetLenth(int lenth)
    {
        slider.value = lenth;
    }
    public void SetScore(int cost)
    {
        costText.text = cost.ToString();
    }
    public void ShowPanel(int cost, int score)
    {
        panel.gameObject.SetActive(true);
        panel.InitPanel(cost,score, ToDoHit,ToDoSub);
    }
    public void ToDoHit()
    {
        OnDoHit?.Invoke();
        panel.gameObject.SetActive(false);
    }
    public void ToDoSub(int cost)
    {
        OnDoSub?.Invoke(cost);
        panel.gameObject.SetActive(false);
    }
}


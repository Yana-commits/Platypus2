using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private CameraController camera;
    [SerializeField] private TileGenerator generator;
    [SerializeField] private HUD hud;

    [SerializeField] private PlayerSettings settings;
    [SerializeField] private TileRepository tiles;

    private int score = 0;

    public Action OnHitEnemy;
    public Action OnSubEnemy;
    void Awake()
    {
        player.Init(settings);
    }
    private void Start()
    {
        generator.Init(player.gameObject.transform, tiles);
        camera.Init(player.gameObject.transform);

        generator.OnTouchCoin += AddCoins;
        generator.OnNextTile += ShowRoad;
        generator.OnTouchEnemy += ShowPanel;

        hud.OnDoHit += ToHitEnemy;
        hud.OnDoSub += SubtractCoins;
    }

    public void AddCoins(int cost)
    {
        score += cost;
        hud.SetScore(score);
    }
    public void SubtractCoins(int cost)
    {
        OnSubEnemy?.Invoke();
        score -= cost;
        player.Init(settings);
        player.animator.SetTrigger("Go");
    }
    public void ToHitEnemy()
    {
        player.animator.SetTrigger("Hit");
        StartCoroutine(HitAct());
    }

    private IEnumerator HitAct()
    {
        yield return new WaitForSeconds(2.5f);
        OnHitEnemy?.Invoke();
        player.Init(settings);
    }
   
    public void ShowRoad(int tiles)
    {
        hud.SetLenth(tiles);
    }
    public void ShowPanel(int cost)
    {
        player.speed = 0;
        player.animator.SetTrigger("Stop");
        hud.ShowPanel(cost, score);
    }

    private void OnDestroy()
    {
        generator.OnTouchCoin -= AddCoins;
        generator.OnNextTile -= ShowRoad;
        generator.OnTouchEnemy -= SubtractCoins;

        hud.OnDoHit -= ToHitEnemy;
        hud.OnDoSub -= SubtractCoins;
    }
}

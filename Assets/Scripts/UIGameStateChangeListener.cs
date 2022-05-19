﻿using System.Collections.Generic;
using UnityEngine;

public class UIGameStateChangeListener : GameStateChangeListener
{
    [Header("Object References")]
    public GameObject canvasSearchShip;
    public GameObject canvasCollectItems;
    public GameObject canvasShipSinking;
    public GameObject canvasAllDone;

    [Header("State")]
    private List<GameObject> _canvases;

    public override void GameStateChanged(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.SHIP_SINKING:
                ShowCanvas(canvasShipSinking);
                break;
            case GameState.COLLECT_INVENTORY_SEARCH_REGION01:
            case GameState.COLLECT_INVENTORY_SEARCH_REGION01_ITEM01:
            case GameState.COLLECT_INVENTORY_SEARCH_REGION01_ITEM02:
            case GameState.COLLECT_INVENTORY_SEARCH_REGION02:
            case GameState.COLLECT_INVENTORY_SEARCH_REGION02_ITEM01:
            case GameState.COLLECT_INVENTORY_SEARCH_REGION02_ITEM02:
            case GameState.COLLECT_INVENTORY_SEARCH_REGION03:
            case GameState.COLLECT_INVENTORY_SEARCH_REGION03_ITEM01:
            case GameState.COLLECT_INVENTORY_SEARCH_REGION03_ITEM02:
            case GameState.COLLECT_INVENTORY_SEARCH_REGION04:
            case GameState.COLLECT_INVENTORY_SEARCH_REGION04_ITEM01:
            case GameState.COLLECT_INVENTORY_SEARCH_REGION04_ITEM02:
                ShowCanvas(canvasCollectItems);
                break;
            case GameState.SEARCH_SHIPWRECK:
                ShowCanvas(canvasSearchShip);
                break;
            case GameState.SUCCESS:
                ShowCanvas(canvasAllDone);
                break;
            default:
                ShowCanvas(canvasSearchShip);
                break;
        }
    }

    private void ShowCanvas(GameObject activeCanvas) {
        foreach (var canvas in GetCanvases()) 
            canvas.SetActive(canvas.Equals(activeCanvas));
    }

    private IEnumerable<GameObject> GetCanvases()
    {
        if (_canvases != null) return _canvases;
        _canvases = new List<GameObject>
        {
            canvasShipSinking,
            canvasCollectItems,
            canvasSearchShip,
            canvasAllDone
        };
        return _canvases;
    }
}
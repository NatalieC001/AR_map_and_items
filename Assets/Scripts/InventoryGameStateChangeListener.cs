using System.Collections.Generic;
using UnityEngine;

public class InventoryGameStateChangeListener : GameStateChangeListener
{
    [Header("Object References")]
    public bool foundRegion1;
    public bool foundRegion1Item1;
    public bool foundRegion1Item2;
    public bool foundRegion2;
    public bool foundRegion2Item1;
    public bool foundRegion2Item2;
    public bool foundRegion3;
    public bool foundRegion3Item1;
    public bool foundRegion3Item2;
    public bool foundRegion4;
    public bool foundRegion4Item1;
    public bool foundRegion4Item2;

    void Start()
    {
        InitOnStart();
    }

    private void InitOnStart()
    {
        foundRegion1 = false;
        foundRegion1Item1 = false;
        foundRegion1Item2 = false;
        foundRegion2 = false;
        foundRegion2Item1 = false;
        foundRegion2Item2 = false;
        foundRegion3 = false;
        foundRegion3Item1 = false;
        foundRegion3Item2 = false;
        foundRegion4 = false;
        foundRegion4Item1 = false;
        foundRegion4Item2 = false;
    }
        
    public override void GameStateChanged(GameState newGameState)
    {
        switch (newGameState)
        {
            case GameState.SHIP_SINKING:
                break;
            case GameState.COLLECT_INVENTORY_SEARCH:
                break;
            case GameState.SEARCH_SHIPWRECK:
                break;
            case GameState.SUCCESS:
                break;
            default:
                break;
        }
    }
    
}
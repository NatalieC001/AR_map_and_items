using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    SEARCH_SHIPWRECK,
    COLLECT_INVENTORY_SEARCH,
    SHIP_SINKING,
    SUCCESS
}

public class GameStateHandler : MonoBehaviour
{
    [Header("Object References")] 
    private static GameStateHandler _gameStateHandler;
    private GameStateChangedEvent _gameStateChangedEvent;
    [SerializeField] private IslandsHandler islandsHandler;
    [SerializeField] private InventoryHandler inventoryHandler;

    [Header("State")] 
    private GameState _state;
    [SerializeField] private TextMeshProUGUI tmpLabel;
    [SerializeField] private TextMeshProUGUI searchNextHintLabel;
    
    public static GameStateHandler Instance
    {
        get
        {
            if (_gameStateHandler) return _gameStateHandler;
            _gameStateHandler = FindObjectOfType(typeof(GameStateHandler)) as GameStateHandler;
            if (!_gameStateHandler)
                Debug.LogError("There needs to be an active GameStateHandler script in a GameObject in the scene");
            else _gameStateHandler.Init();
            return _gameStateHandler;
        }
    }

    private void Init()
    {
        if (_gameStateChangedEvent == null)
            _gameStateChangedEvent = new GameStateChangedEvent();
    }

    void Start()
    {
        InitOnStart();
    }

    private void InitOnStart()
    {
        SwitchState(GameState.SEARCH_SHIPWRECK);
    }

    public static void StartListening(UnityAction<GameState> listener)
    {
        Instance._gameStateChangedEvent.AddListener(listener);
    }

    public static void StopListening(UnityAction<GameState> listener)
    {
        if (Instance == null) return;
        if (_gameStateHandler == null) return;
        Instance._gameStateChangedEvent.RemoveListener(listener);
    }

    public void TriggerEvent(GameState newAppState)
    {
        _gameStateChangedEvent.Invoke(newAppState);
    }

    public GameState CurrentState()
    {
        return _state;
    }

    public void SwitchState(GameState newGameState)
    {
        _state = newGameState;
        _gameStateHandler.TriggerEvent(_state);
    }
    
    public void ImageFound(string imageName)
    {
        switch (imageName)
        {
            case "MapShip":
                FoundMapShipImage(imageName);
                break;
            case "Region01Item01":
            case "Region01Item02": 
            case "Region02Item01":
            case "Region02Item02":
            case "Region03Item01":
            case "Region03Item02": 
            case "Region04Item01":
            case "Region04Item02":
                FoundInventoryImage(imageName);
                break;
            case "Region01":
            case "Region02":
            case "Region03":
            case "Region04":
                FoundRegionImage(imageName);
                break;
            default:
                break;
        }
    }

    private void FoundRegionImage(string imageName)
    {
        tmpLabel.text = "Region Image: " + imageName;
        Debug.Log("You found" + imageName);
        switch (imageName)
        {
            // TODO Natty - this is currently only set up for 4 regions, it disregards any items
            // we need to discuss, if you want to track all items individually, or if it is a single run through
            // that is mainly interesting, if people rescan old images or if you want to display the inventory
            
            case "Region01":
                islandsHandler.FoundRegion01();
                break;
            case "Region02":
                islandsHandler.FoundRegion02();
                break;
            case "Region03":
                islandsHandler.FoundRegion03();
                break;
            case "Region04":
                islandsHandler.FoundRegion04();
                break;
        }
        GetNextHint();
    }

    private void GetNextHint()
    {
        if (islandsHandler.hasFoundIsland04)
        {
            ShowHint("Successfully found all items");
            SwitchState(GameState.SUCCESS);
        }
        else if (islandsHandler.hasFoundIsland03)
            ShowHint("Search Island 4");
        else if (islandsHandler.hasFoundIsland02)
            ShowHint("Search Island 3");
        else if (islandsHandler.hasFoundIsland01)
            ShowHint("Search Island 2");
        else
            ShowHint("Search Island 1");
    }

    private void ShowHint(string searchIsland)
    {
        searchNextHintLabel.text = "Hint: " + searchIsland;
    }

    private void FoundInventoryImage(string imageName)
    {
        tmpLabel.text = "Inventory Image: " + imageName;
        Debug.Log("You found" + imageName);
        switch (imageName)
        {
            case "Region01Item01":
                // SwitchState(GameState.COLLECT_INVENTORY_SEARCH_REGION01_ITEM02);
                break;
            case "Region01Item02":
                // SwitchState(GameState.COLLECT_INVENTORY_SEARCH_REGION02);
                break;
            case "Region02Item01":
                // SwitchState(GameState.COLLECT_INVENTORY_SEARCH_REGION02_ITEM02);
                break;
            case "Region02Item02":
                // SwitchState(GameState.COLLECT_INVENTORY_SEARCH_REGION03);
                break;
            case "Region03Item01":
                // SwitchState(GameState.COLLECT_INVENTORY_SEARCH_REGION03_ITEM02);
                break;
            case "Region03Item02":
                // SwitchState(GameState.COLLECT_INVENTORY_SEARCH_REGION04);
                break;
            case "Region04Item01":
                // SwitchState(GameState.COLLECT_INVENTORY_SEARCH_REGION04_ITEM02);
                break;
            case "Region04Item02":
                SwitchState(GameState.SUCCESS);
                break;
        }
    }
    
    private void FoundMapShipImage(string imageName)
    {
        tmpLabel.text = "last image: " + imageName;
        Debug.Log("You found" + imageName);
        SwitchState(GameState.COLLECT_INVENTORY_SEARCH);
        GetNextHint();
    }
}
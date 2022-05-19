using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState
{
    SEARCH_SHIPWRECK,
    COLLECT_ITEMS,
    SHIP_SINKING
}

public class GameStateHandler : MonoBehaviour
{
    [Header("Object References")]
    private static GameStateHandler gameStateHandler;
    private GameStateChangedEvent gameStateChangedEvent;

    [Header("State")]
    private GameState state;
    
    public static GameStateHandler Instance
    {
        get
        {
            if (gameStateHandler) return gameStateHandler;
            gameStateHandler = FindObjectOfType(typeof(GameStateHandler)) as GameStateHandler;
            if (!gameStateHandler) Debug.LogError("There needs to be an active GameStateHandler script in a GameObject in the scene");
            else gameStateHandler.Init();
            return gameStateHandler;
        }
    }

    private void Init()
    {
        if (gameStateChangedEvent == null)
            gameStateChangedEvent = new GameStateChangedEvent();
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
        Instance.gameStateChangedEvent.AddListener(listener);
    }

    public static void StopListening(UnityAction<GameState> listener)
    {
        if (Instance == null) return;
        if (gameStateHandler == null) return;
        Instance.gameStateChangedEvent.RemoveListener(listener);
    }
    
    public void TriggerEvent(GameState newAppState)
    {
        gameStateChangedEvent.Invoke(newAppState);
    }

    public GameState CurrentState()
    {
        return state;
    }

    public void SwitchState(GameState newGameState)
    {
        state = newGameState;
        gameStateHandler.TriggerEvent(state);
    }


}

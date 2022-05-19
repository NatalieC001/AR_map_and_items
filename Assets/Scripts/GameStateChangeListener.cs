using UnityEngine;

public class GameStateChangeListener : MonoBehaviour
{

    public void Awake() {
        GameStateHandler.StartListening (GameStateChanged);
    }

    public void OnDestroy() {
        GameStateHandler.StopListening (GameStateChanged);
    }

    public virtual void GameStateChanged(GameState newGameState) {
        //Debug.Log ("__StateChange received. New State: " + newAppState.ToString ());
    }
}
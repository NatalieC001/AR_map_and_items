using System.Collections.Generic;
using UnityEngine;

namespace GroupDraw.Scripts.State
{
    public class UIGameStateChangeListener : GameStateChangeListener
    {
        [Header("Object References")]
        public GameObject CanvasShipSinking;
        public GameObject CanvasCollectItems;
        public GameObject CanvasSearchShip;

        [Header("State")]
        private List<GameObject> canvases;

        [Header("Class Logging")]
        [SerializeField]
        private bool isLogging;
        
        public override void GameStateChanged(GameState newGameState)
        {
            switch (newGameState)
            {
                case GameState.SHIP_SINKING:
                    ShowCanvas(CanvasShipSinking);
                    break;
                case GameState.COLLECT_ITEMS:
                    ShowCanvas(CanvasCollectItems);
                    break;
                case GameState.SEARCH_SHIPWRECK:
                    ShowCanvas(CanvasSearchShip);
                    break;
                default:
                    ShowCanvas(CanvasSearchShip);
                    break;
            }
        }

        private void ShowCanvas(GameObject activeCanvas) {
            foreach (var canvas in GetCanvases()) 
                canvas.SetActive(canvas.Equals(activeCanvas));
        }
    

        private IEnumerable<GameObject> GetCanvases()
        {
            if (canvases != null) return canvases;

            canvases = new List<GameObject>
            {
                CanvasShipSinking,
                CanvasCollectItems,
                CanvasSearchShip, 
            };
            return canvases;
        }
    }
}

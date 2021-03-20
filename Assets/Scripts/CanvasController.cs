using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

    public GameObject gameUI;
    public GameObject pauseMenu;

    public void ManageCanvas(GameController.GameState gameState, float timeScale = 0f) {
        gameUI.SetActive(gameState == GameController.GameState.Running);
        pauseMenu.SetActive(gameState == GameController.GameState.Paused);
        Time.timeScale = timeScale;
    }

}

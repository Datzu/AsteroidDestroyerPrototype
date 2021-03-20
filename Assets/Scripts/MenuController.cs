using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void StartGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void ExitGame() {
        Application.Quit();
    }
}

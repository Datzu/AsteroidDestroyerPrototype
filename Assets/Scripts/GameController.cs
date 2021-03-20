using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject asteroidArrayPrefab;
    public GameObject asteroidGroup;
    public GameObject spawnZone;
    public GameObject player;
    public Text text;
    private int score = 0;
    private GameState gameState = GameState.Running;

    public CanvasController canvasController;

    void Start() {
        if (asteroidArrayPrefab) {
            SpawnAsteroidConfig spawnAsteroidConfig = new SpawnAsteroidConfig();

            List<GameObject> asteroidsList = new List<GameObject>();

            foreach (Transform child in asteroidArrayPrefab.transform) {
                child.gameObject.GetComponent<AsteroidController>().spawnZone = spawnZone.GetComponent<Collider2D>();
                child.gameObject.GetComponent<AsteroidController>().gameController = this;
                asteroidsList.Add(child.gameObject);
            }

            spawnAsteroidConfig.SetAsteroidToSpawn(asteroidsList);
            spawnAsteroidConfig.SetMaxAsteroidsToSpawn(10);
            StartCoroutine("CreateAsteroids", spawnAsteroidConfig);
        }

        Camera cam = GetComponentInParent<Camera>();

        float aspect = (float) Screen.width / Screen.height;
        float orthoSize = cam.orthographicSize;
 
        float width = 2.0f * orthoSize * aspect;
        float height = 2.0f * cam.orthographicSize;
 
        GetComponent<BoxCollider2D>().size = new Vector2(width, height);
    }

    private IEnumerator CreateAsteroids(SpawnAsteroidConfig spawnAsteroidConfig) {
        for (int i = 0; i < spawnAsteroidConfig.GetMaxAsteroidsToSpawn(); i++) {
            yield return new WaitForSeconds(spawnAsteroidConfig.GetSeconds());

            this.CreateAsteroid(spawnAsteroidConfig);
        }
    }

    public bool isRunning() {
        return gameState == GameState.Running;
    }

    private void CreateAsteroid(SpawnAsteroidConfig spawnAsteroidConfig) {
        GameObject newAsteroid = Instantiate(spawnAsteroidConfig.GetAsteroidToSpawn(), new Vector2(-20f, 0f), Quaternion.identity);
        newAsteroid.transform.SetParent(asteroidGroup.transform);   
    }

    public void IncreaseScore(int points) {
        this.score += points;

        text.text = "Score: " + score;
    }

    private void Update() {
        //TODO Refactor this
        bool needChangeState = false;
        float timeScale = 0f;

        if (gameState == GameState.Running && Input.GetKeyDown(KeyCode.Escape)) {
            needChangeState = true;
            gameState = GameState.Paused;
            timeScale = 0f;
        } else if (gameState == GameState.Paused && Input.GetKeyDown(KeyCode.Escape)) {
            needChangeState = true;
            gameState = GameState.Running;
            timeScale = 1.0f;
        }

        if (needChangeState) {
            canvasController.ManageCanvas(gameState, timeScale);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Projectile") {
            Destroy(other.gameObject);
        }

        if (other.tag == "Player") {
            player.GetComponent<PlayerController>().EndGame();
        }
    }

    public enum GameState {
        Running, Paused
    }

}

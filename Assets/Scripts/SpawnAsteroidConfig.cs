using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroidConfig {

    List<GameObject> asteroidList;
    int minSeconds = 0;
    int maxSeconds = 0;

    int maxAsteroidsToSpawn = 0;

    public void SetAsteroidToSpawn(List<GameObject> asteroidList) {
        this.asteroidList = asteroidList;
    }

    public GameObject GetAsteroidToSpawn() {
        return asteroidList[Random.Range (0, asteroidList.Count - 1)];
    }

    public void SetSeconds(int minSeconds, int maxSeconds) {
        this.minSeconds = minSeconds;
        this.maxSeconds = maxSeconds;
    }

    public int GetSeconds() {
        return Random.Range(minSeconds, maxSeconds);
    }

    public void SetMaxAsteroidsToSpawn(int maxAsteroidsToSpawn) {
        this.maxAsteroidsToSpawn = maxAsteroidsToSpawn;
    }

    public int GetMaxAsteroidsToSpawn() {
        return maxAsteroidsToSpawn;
    }

}
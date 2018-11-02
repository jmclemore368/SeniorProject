using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private static GameController singleton;
    [SerializeField]
    AlienSpawnPoint[] alienSpawnPoints;
    public int enemiesLeft;

    void Start()
    {
        singleton = this;
        SpawnAliens();
    }

    private void SpawnAliens()
    {
        foreach (AlienSpawnPoint alienSpawnPoint in alienSpawnPoints)
        {
            alienSpawnPoint.SpawnAlien();
            enemiesLeft++;
        }
    }

}

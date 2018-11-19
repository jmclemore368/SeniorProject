using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnPoint : MonoBehaviour {

    [SerializeField]
    GameObject[] aliens;
    private int timesSpawned; // Wave #
    private int healthBonus = 0;


	public void SpawnAlien()
    {
        timesSpawned++;
        healthBonus += 100 * timesSpawned;
        GameObject alien = Instantiate(aliens[Random.Range(0, aliens.Length)]);
        alien.transform.position = transform.position;

        Health alienHealth = alien.GetComponent<Health>();
        alienHealth.SetStartingHealth(
            (int)alienHealth.getStartingHealth() + healthBonus
        );
    }
}

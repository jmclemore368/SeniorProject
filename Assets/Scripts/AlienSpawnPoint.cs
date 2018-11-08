using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienSpawnPoint : MonoBehaviour {

    [SerializeField]
    GameObject[] aliens;
    private int timesSpawned;
    private int healthBonus = 0; // Increase health each wave to make harder

    public void SpawnAlien()
    {
        timesSpawned++;
        healthBonus += 100 * timesSpawned;
        Debug.Log("Spawning Alien with Health Bonus of: " + healthBonus);
        GameObject alien = Instantiate(aliens[Random.Range(0, aliens.Length)]);
        alien.transform.position = transform.position;
        alien.GetComponent<Health>().ChangeHealth(healthBonus); 
    }
}

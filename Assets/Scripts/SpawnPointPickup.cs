using System.Collections;
using UnityEngine;

public class SpawnPointPickup : MonoBehaviour {
    [SerializeField] private GameObject[] pickups;
    private int respawnTimeSeconds = 30;

    void Start() {
        spawnPickup();
    }

    void spawnPickup() {
        GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;
    }

    IEnumerator respawnPickup() {
        yield return new WaitForSeconds(respawnTimeSeconds);
        spawnPickup();
    }
	
    public void startRespawnTimer() {
        StartCoroutine("respawnPickup");
    }
}

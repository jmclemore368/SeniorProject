using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] pickups;

    // Spawn a random pickup
    void spawnPickup()
    {
        GameObject pickup = Instantiate(pickups[Random.Range(0, pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;
    }

    IEnumerator respawnPickup()
    {
        yield return new WaitForSeconds(20);
        spawnPickup();
    }

	// Use this for initialization
	void Start () {
        spawnPickup();
	}
	
    // Start respawn timer
    public void didPickup()
    {
        StartCoroutine("respawnPickup");
    }

	// Update is called once per frame
	void Update () {
		
	}
}

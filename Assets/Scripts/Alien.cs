using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

    public int health; // HP of the alien
    public int range; // How far the alien must be before shooting its gun
    public float fireRate; // How fast the alien can fire its gun
    public Transform missileFireSpot;  // Location from which the special ability is launched
    UnityEngine.AI.NavMeshAgent agent; // Ref to the NavMesh Agent component
    private Transform player; // Ref to the player which the alien tries to find
    private float timeLastFired;
    private bool isDead; // If the alien is alive or not

	// Use this for initialization
	void Start () {
        // Alien is alive by default.
        // Set refs to the NavMesh Agent and Player component  
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead) {
            return;
        }
        transform.LookAt(player); // Alien faces player
        agent.SetDestination(player.position); // Alien uses Nav Mesh to find player

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        bool alienIsWithinRange = distanceToPlayer < range;
        float timeSinceLastShot = Time.time - timeLastFired;
        bool alienCanFireAgain = timeSinceLastShot > fireRate;

        if (alienIsWithinRange && alienCanFireAgain) {
            timeLastFired = Time.time;
            fire();
        }
    }
    private void fire() {
        Debug.Log("Firing...");
    }
}

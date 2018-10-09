using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    public int health; // HP of the alien ******
    public int firingRange; // How far the alien must be before shooting its gun
    public float firingRate; // How fast the alien can fire its gun
    public Transform firingLocation;  // Coordinate on model where bullets fire
    UnityEngine.AI.NavMeshAgent agent; // Ref to the NavMesh Agent component ******
    private Transform player; // Ref to the player which the alien tries to find ******
    private float timeLastFired; // ****
    private bool isDead; // If the alien is alive or not ****
    public Animator alien; // For playing animations

    // Use this for initialization
    void Start()
    {
        // Alien is alive by default.
        // Set refs to the NavMesh Agent and Player component  
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            return;
        }
        transform.LookAt(player); // Alien faces player
        agent.SetDestination(player.position); // Alien uses Nav Mesh to find player

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        bool alienIsWithinFiringRange = distanceToPlayer < firingRange;
        float timeSinceLastFired = Time.time - timeLastFired;
        bool alienCanFireAgain = timeSinceLastFired > firingRate;

        if (alienIsWithinFiringRange && alienCanFireAgain)
        {
            timeLastFired = Time.time;
            fire();
        }
    }

    private void fire()
    {
        alien.Play("fire");
    }
}